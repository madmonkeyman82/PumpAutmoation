using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using NextUI;
using NextUI.BaseUI;
using NextUI.Frame;
using NextUI.Component;


namespace PumpAutomation
{

    public class Gauges
    {


        // GUI 
        const int GaugeFlowXpos = 4;
        const int GaugeFlowYpos = 10;
        const int GaugeFlowDiameter = 240;

        const int GaugePressureXpos = GaugeFlowDiameter + GaugeFlowXpos + 6;
        const int GaugePressureYpos = GaugeFlowYpos;
        const int GaugePressureDiameter = 150;

        const int GaugeRegXpos = 5;
        const int GaugeRegYpos = 5;
        const int GaugeRegXWidth = 395;
        const int GaugeRegXHeight = 70;

        const int RegSPSendDealyMs = 300;

        // The delegate procedure we are assigning to our object
       // public delegate void ShipmentHandler(object myObject, ShipArgs myArgs);
        public delegate void ShipmentHandler(object myObject, GaugeArgs myArgs);

        public event ShipmentHandler Regulator1SP;
        public event ShipmentHandler Regulator2SP;

        private Timer delay;
        private Timer delay2;

        public  Gauges()
        {

            StartTimers();
        }

        #region Event`s

        private bool delayOn = false;
        private bool delayOn2 = false;
        private float _SetPoint;
        private float _SetPoint2;

        void StartTimers()
        {
            delay = new Timer();
            delay.Interval = RegSPSendDealyMs;
            delay.Tick += delay_Tick;
            delay2 = new Timer();
            delay2.Interval = RegSPSendDealyMs;
            delay2.Tick += delay_Tick2;
        }

        void delay_Tick(object sender, EventArgs e)
        {
            delayOn = false;
            delay.Stop();
        }
        void delay_Tick2(object sender, EventArgs e)
        {
            delayOn2 = false;
            delay2.Stop();
        }

        private float Reg1SP
        {
            set
            {
                if (!delayOn)
                {
                    delayOn = true;
                    delay.Start();
                _SetPoint = value;

                GaugeArgs myArgs = new GaugeArgs(_SetPoint);

                    // Tracking number is available, raise the event.
                Regulator1SP(this, myArgs);
                }
            }
        }
        private float Reg2SP
        {
            set
            {
                if (!delayOn2)
                {
                    delayOn2 = true;
                    delay2.Start();
                    _SetPoint2 = value;

                    GaugeArgs myArgs = new GaugeArgs(_SetPoint2);

                    // Tracking number is available, raise the event.
                    Regulator2SP(this, myArgs);
                }
            }
        }

        private void DoStart(object obj, float newSP)
        {
            Reg1SP = newSP;
        }
        private void DoStart2(object obj, float newSP)
        {
            Reg2SP = newSP;
        }
        
        #endregion


        #region  Pump1

        public void Pump1(ref BaseUI baseUI, ref BaseUI baseUI2)
        {
            //LoadGaugePump1Flow(ref baseUI);
            GaugeFlow(ref baseUI);
            GaugePressure(ref baseUI);

            LoadGaugePump1Regulator(ref baseUI2);
        }

        private void LoadGaugePump1Regulator(ref BaseUI _baseUI)
        {
            HorizontalFrame hf = new HorizontalFrame(new Rectangle(GaugeRegXpos, GaugeRegYpos, GaugeRegXWidth, GaugeRegXHeight));
            _baseUI.Frame.Add(hf);

            NextUI.Component.HorizontalScaleBar bar1 = new NextUI.Component.HorizontalScaleBar(hf);
            hf.ScaleCollection.Add(bar1);

            bar1.OffsetFromFrame = 12;
            bar1.ScaleBarSize = 8;
            bar1.BorderStyle = ScaleBase.Style.DashDotDot;
            bar1.TickMajor.Width = 6;
            bar1.TickMajor.Height = 20;
            bar1.TickMajor.FillColor = Color.DarkBlue;
            bar1.TickMinor.Width = 2;
            bar1.TickMinor.Height = 3;
            bar1.TickMinor.FillColor = Color.AliceBlue;

            bar1.StartValue = 0;
            bar1.EndValue = 100;
            bar1.MajorTickNumber = 11;
            bar1.MinorTicknumber = 0;

            bar1.TickLabel.LabelFont = new Font("Elephant", 14, FontStyle.Bold);
            bar1.TickLabel.OffsetFromScale = 18;
            bar1.TickLabel.Angle = 80;


            HorizontalPointer pointer = new HorizontalPointer(hf);
            bar1.Pointer.Add(pointer);

            pointer.BasePointer.PointerShapeType = Pointerbase.PointerType.Type4;
            pointer.BasePointer.Width = 10;
            pointer.BasePointer.Length = 35;
            pointer.BasePointer.Shadow.Offset = 3;
            pointer.BasePointer.OffsetFromCenter = 23;
            pointer.BasePointer.FillColor = Color.DarkRed;

            LinearRange range = new LinearRange(hf);
            bar1.Range.Add(range);

            range.StartValue = 80;
            range.EndValue = 100;
            range.StartWidth = 5;
            range.EndWidth = 10;


            _baseUI.Interact = true;

            bar1.Drag += new HorizontalScaleBar.OnDrag(DoStart);

        }

        #endregion

        #region Pump 2

        // Pump2
        public void Pump2(ref BaseUI baseUI, ref BaseUI baseUI2)
        {
            //LoadGaugePump2Flow(ref baseUI);
            GaugeFlow(ref baseUI);
            GaugePressure(ref baseUI);
            
            LoadGaugePump2Regulator(ref baseUI2);
        }

        private void LoadGaugePump2Regulator(ref BaseUI baseUI)
        {
            HorizontalFrame hf = new HorizontalFrame(new Rectangle(GaugeRegXpos, GaugeRegYpos, GaugeRegXWidth, GaugeRegXHeight));
            baseUI.Frame.Add(hf);

            NextUI.Component.HorizontalScaleBar bar1 = new NextUI.Component.HorizontalScaleBar(hf);
            hf.ScaleCollection.Add(bar1);

            bar1.OffsetFromFrame = 12;
            bar1.ScaleBarSize = 8;
            bar1.BorderStyle = ScaleBase.Style.DashDotDot;
            bar1.TickMajor.Width = 6;
            bar1.TickMajor.Height = 20;
            bar1.TickMajor.FillColor = Color.DarkBlue;
            bar1.TickMinor.Width = 2;
            bar1.TickMinor.Height = 3;
            bar1.TickMinor.FillColor = Color.AliceBlue;

            bar1.StartValue = 0;
            bar1.EndValue = 100;
            bar1.MajorTickNumber = 11;
            bar1.MinorTicknumber = 0;

            bar1.TickLabel.LabelFont = new Font("Elephant", 14, FontStyle.Bold);
            bar1.TickLabel.OffsetFromScale = 18;
            bar1.TickLabel.Angle = 80;


            HorizontalPointer pointer = new HorizontalPointer(hf);
            bar1.Pointer.Add(pointer);

            pointer.BasePointer.PointerShapeType = Pointerbase.PointerType.Type4;
            pointer.BasePointer.Width = 10;
            pointer.BasePointer.Length = 35;
            pointer.BasePointer.Shadow.Offset = 3;
            pointer.BasePointer.OffsetFromCenter = 23;
            pointer.BasePointer.FillColor = Color.DarkRed;

            LinearRange range = new LinearRange(hf);
            bar1.Range.Add(range);

            range.StartValue = 80;
            range.EndValue = 100;
            range.StartWidth = 5;
            range.EndWidth = 10;


            baseUI.Interact = true;

            bar1.Drag += new HorizontalScaleBar.OnDrag(DoStart2);

        }
        #endregion

        #region Average Gauge

        public void AverageGauge(ref BaseUI baseUI)
        {
            LoadGaugeAverageFlow(ref baseUI);
        }
        
        private void LoadGaugeAverageFlow(ref BaseUI baseUI)
        {
            CircularFrame f1 = new CircularFrame(new Point(GaugeFlowXpos, GaugeFlowYpos), GaugeFlowDiameter);
            baseUI.Frame.Add(f1);
            f1.BackRenderer.CenterColor = Color.Black;

            // Pumpe Label
            GaugeLable(f1, new Point(f1.Rect.Width / 2 - 25, f1.Rect.Height / 2 - 58), "Total", 20);
            GaugeLable(f1, new Point(f1.Rect.Width / 2 - 30, f1.Rect.Height / 2 - 40), "L/Min", 20);

            // Tess Label
            GaugeLable(f1, new Point(f1.Rect.Width / 2 - 20, f1.Rect.Height / 2 - 70));



            CircularScaleBar bar1 = new CircularScaleBar(f1);
            bar1.OffsetFromFrame = 12;
            bar1.ScaleBarSize = 6;
            bar1.BorderStyle = ScaleBase.Style.NotSet;
            bar1.TickMajor.Width = 5;
            bar1.TickMajor.Height = 8;
            bar1.TickMajor.FillColor = Color.DarkBlue;
            bar1.TickMinor.Width = 2;
            bar1.TickMinor.Height = 4;
            bar1.TickMinor.FillColor = Color.DarkBlue;

            bar1.StartAngle = 80;
            bar1.SweepAngle = 20;

            bar1.StartValue = 0;
            bar1.EndValue = 600;
            bar1.MajorTickNumber = 11;
            bar1.MinorTicknumber = 2;

            bar1.TickLabel.LabelFont = new Font("Elephant", 12, FontStyle.Bold);
            bar1.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            bar1.TickLabel.OffsetFromScale = 15;

            f1.ScaleCollection.Add(bar1);


            CircularPointer pointer = new CircularPointer(f1);
            pointer.BasePointer.PointerShapeType = Pointerbase.PointerType.Type1;
            pointer.BasePointer.Width = 7;
            pointer.BasePointer.Length = 105;
            pointer.BasePointer.Shadow.Offset = 3;
            pointer.CapPointer.FillColor = Color.DarkSlateBlue;
            pointer.BasePointer.OffsetFromCenter = -20;
            pointer.BasePointer.FillColor = Color.DarkRed;

            // Danger zone marking
            CircularRange range1 = new CircularRange(f1);
            bar1.Range.Add(range1);

            range1.StartValue = 500;
            range1.EndValue = 600;
            range1.StartWidth = 3;
            range1.EndWidth = 15;
            range1.RangePosition = RangeBase.Position.Cross;
            range1.FillColor = Color.Red;

            bar1.Pointer.Add(pointer);

        }

#endregion

        #region tools

        private void GaugeFlow(ref BaseUI baseUI)
        {
            CircularFrame f1 = new CircularFrame(new Point(GaugeFlowXpos, GaugeFlowYpos), GaugeFlowDiameter);
            baseUI.Frame.Add(f1);
            f1.BackRenderer.CenterColor = Color.Black;

            // Pumpe Label
            GaugeLable(f1, new Point(f1.Rect.Width / 2 - 30, f1.Rect.Height / 2 - 50), "L/Min");

            // Tess Label
            GaugeLable(f1, new Point(f1.Rect.Width / 2 - 20, f1.Rect.Height / 2 - 70));

            CircularScaleBar bar1 = new CircularScaleBar(f1);
            bar1.OffsetFromFrame = 12;
            bar1.ScaleBarSize = 6;
            bar1.BorderStyle = ScaleBase.Style.NotSet;
            bar1.TickMajor.Width = 5;
            bar1.TickMajor.Height = 8;
            bar1.TickMajor.FillColor = Color.DarkBlue;
            bar1.TickMinor.Width = 2;
            bar1.TickMinor.Height = 4;
            bar1.TickMinor.FillColor = Color.DarkBlue;

            bar1.StartAngle = 75;
            bar1.SweepAngle = 30;

            bar1.StartValue = 0;
            bar1.EndValue = 300;
            bar1.MajorTickNumber = 11;
            bar1.MinorTicknumber = 2;
            bar1.CustomLabel = new string[] { "<15", "30", "60", "90", "120", "150", "180", "210", "240", "270", "300" };

            bar1.TickLabel.LabelFont = new Font("Elephant", 9, FontStyle.Bold);
            bar1.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            bar1.TickLabel.OffsetFromScale = 15;

            f1.ScaleCollection.Add(bar1);


            CircularPointer pointer = new CircularPointer(f1);
            pointer.BasePointer.PointerShapeType = Pointerbase.PointerType.Type1;
            pointer.BasePointer.Width = 7;
            pointer.BasePointer.Length = 100;
            pointer.BasePointer.Shadow.Offset = 3;
            pointer.CapPointer.FillColor = Color.DarkSlateBlue;
            pointer.BasePointer.OffsetFromCenter = -20;
            pointer.BasePointer.FillColor = Color.DarkRed;
            pointer.CapPointer.Diameter = 20;

            // Danger zone marking
            CircularRange range1 = new CircularRange(f1);
            bar1.Range.Add(range1);

            range1.StartValue = 250;
            range1.EndValue = 300;
            range1.StartWidth = 3;
            range1.EndWidth = 15;
            range1.RangePosition = RangeBase.Position.Cross;
            range1.FillColor = Color.Red;

            bar1.Pointer.Add(pointer);

        }

        private void GaugePressure(ref BaseUI baseUI)
        {

            CircularFrame f1 = new CircularFrame(new Point(GaugePressureXpos, GaugePressureYpos), GaugePressureDiameter);
            baseUI.Frame.Add(f1);
            f1.BackRenderer.CenterColor = Color.Black;


            // Pumpe Label
            GaugeLable(f1, new Point(f1.Rect.Width / 2 - 14, f1.Rect.Height / 2 - 25), "Bar", 15);


            // Tess Label
            // GaugeLable(f1, new Point(f1.Rect.Width / 2 - 20, f1.Rect.Height / 2 - 70));

            CircularScaleBar bar1 = new CircularScaleBar(f1);
            bar1.OffsetFromFrame = 12;
            bar1.ScaleBarSize = 6;
            bar1.BorderStyle = ScaleBase.Style.NotSet;
            bar1.TickMajor.Width = 5;
            bar1.TickMajor.Height = 8;
            bar1.TickMajor.FillColor = Color.DarkBlue;
            bar1.TickMinor.Width = 2;
            bar1.TickMinor.Height = 3;
            bar1.TickMinor.FillColor = Color.DarkBlue;

            bar1.StartAngle = 80;
            bar1.SweepAngle = 30;

            bar1.StartValue = 0;
            bar1.EndValue = 400;
            bar1.MajorTickNumber = 9;
            bar1.MinorTicknumber = 2;

            bar1.TickLabel.LabelFont = new Font("Elephant", 8, FontStyle.Bold);
            bar1.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            bar1.TickLabel.OffsetFromScale = 15;

            f1.ScaleCollection.Add(bar1);


            CircularPointer pointer = new CircularPointer(f1);
            pointer.BasePointer.PointerShapeType = Pointerbase.PointerType.Type1;
            pointer.BasePointer.Width = 2;
            pointer.BasePointer.Length = 66;
            pointer.BasePointer.Shadow.Offset = 2;
            pointer.CapPointer.FillColor = Color.DarkSlateBlue;
            pointer.BasePointer.OffsetFromCenter = -10;
            pointer.BasePointer.FillColor = Color.DarkRed;
            pointer.CapPointer.Diameter = 10;
            bar1.Pointer.Add(pointer);

            // Danger zone marking
            CircularRange range1 = new CircularRange(f1);
            bar1.Range.Add(range1);

            range1.StartValue = 360;
            range1.EndValue = 400;
            range1.StartWidth = 3;
            range1.EndWidth = 10;
            range1.RangePosition = RangeBase.Position.Cross;
            range1.FillColor = Color.Red;

        }

        private FrameLabel GaugeLable(CircularFrame f1, Point point)
        {
            FrameLabel lb = new FrameLabel(point, f1);
            f1.FrameLabelCollection.Add(lb);
            lb.LabelText = "TESS";
            lb.LabelFont = new Font(FontFamily.GenericSerif,
                                     15,
                /* FontStyle.Italic |*/ FontStyle.Bold
                                     );
            lb.FontColor = Color.Black;
            lb.Shadow.Offset = 1;

            return lb;
        }

        private FrameLabel GaugeLable(CircularFrame f1, Point point, string text)
        {
            FrameLabel lb = new FrameLabel(point, f1);
            f1.FrameLabelCollection.Add(lb);
            lb.LabelText = text;
            lb.LabelFont = new Font(FontFamily.GenericSerif, 15, /* FontStyle.Italic |*/ FontStyle.Bold);
            lb.FontColor = Color.Black;
            lb.Shadow.Offset = 1;

            return lb;
        }

        private FrameLabel GaugeLable(CircularFrame f1, Point point, string text, int size)
        {
            FrameLabel lb = new FrameLabel(point, f1);
            f1.FrameLabelCollection.Add(lb);
            lb.LabelText = text;
            lb.LabelFont = new Font(FontFamily.GenericSerif, size, /* FontStyle.Italic |*/ FontStyle.Bold);
            lb.FontColor = Color.Black;
            lb.Shadow.Offset = 1;

            return lb;
        }
        #endregion
    }
}
