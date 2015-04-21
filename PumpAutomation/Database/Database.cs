using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 
using System.Data.OleDb;
using System.Data;

namespace PumpAutomation.Database
{
   public  class DatabaseLog
    {
        #region Variables

        // Logger Variable
        Logger SingletonLogger = Logger.Instance;

        // Plc Variables
        private Core SingletonCore = Core.Instance;

       //Bool`s
        bool _LoggingOn = false;
        bool _LoggingEnabled = false;
        bool _ContinueLogging = false;
        

       //Int`s
        int _LoggingInterval = 2;
        int _SessionNumber = 0;
        
       //String`s
        string _Costumer = "None";

        // Timers
        private System.Windows.Forms.Timer LogToDBTimer;

        // Thread`s 

       // Database Variables
        string myConnectionString = "Provider =Microsoft.Jet.OLEDB.4.0; Data Source=Log.mdb";
        OleDbConnection myConnection;

        #endregion

        #region Constructor And Deconstructor

        public DatabaseLog()
        {
            if (ConnectToDB())
            {
                SetupTimes();
              //  SetSessionId();

            }       
        }

        ~DatabaseLog()
        {

        }
        #endregion


        #region Public`s


        #endregion

        #region Privates

        void WriteToDb(Dictionary<SensorType, float> dict)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = myConnection;
                if (!myConnection.State.Equals(System.Data.ConnectionState.Open))
                {
                    myConnection.Open(); // open the connection
                } 
 
                List<SensorType> keys = new List<SensorType>(dict.Keys);
                List<float> values = new List<float>(dict.Values);

                //cmd.CommandType = Text;


                for (int i = 0; i < dict.Count; i++)
                {
                   
                    string key = keys[i].ToString();
                    float value = values[i];

                    cmd.CommandText = "INSERT INTO Logging (SensorName, SensorValue, Costumer, SessionId) VALUES (@SensorName, @SensorValue, @Costumer, @SessionId);";

                    cmd.Parameters.AddWithValue("@SensorName", key);
                    cmd.Parameters.AddWithValue("@SensorValue", value);
                    cmd.Parameters.AddWithValue("@Costumer", _Costumer);
                    cmd.Parameters.AddWithValue("@SessionId", _SessionNumber);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    Thread.Sleep(10);
                }


                myConnection.Close();


                SingletonLogger.AddToLog("Records are successfully insert" , LogType.Info, LogModule.DB);
            }
            catch (Exception ex)
            {
                SingletonLogger.AddToLog(ex.ToString(), LogType.Error, LogModule.DB);
            }
        }

        bool ConnectToDB()
        {
            
            myConnection = new OleDbConnection (myConnectionString);

            try
            {
            myConnection.Open ();

            SingletonLogger.AddToLog("Database Connected and Working", LogType.Info, LogModule.DB);
            return true;
            }
            catch(Exception ex)
            {
                SingletonLogger.AddToLog(ex.ToString(), LogType.Error, LogModule.DB);
            }
            myConnection.Close ();
            return false;
        }

        void SetupTimes()
        {
            LogToDBTimer = new System.Windows.Forms.Timer();
            LogToDBTimer.Interval = Properties.Settings.Default.LogToDBInterval * 1000;
            LogToDBTimer.Start();
            LogToDBTimer.Tick += LogToDbTick_Tick;
        }

       public void SetSessionId(bool update=false)
       {
           if (_SessionNumber == 0 | update)
           {
               try
               {
                   OleDbCommand cmd = new OleDbCommand();
                   cmd.Connection = myConnection;
                   if (!myConnection.State.Equals(System.Data.ConnectionState.Open))
                   {
                       myConnection.Open(); // open the connection
                   }


                   var query = "SELECT SessionId FROM Logging";
                   var adapter = new OleDbDataAdapter(query, myConnection);

                   var myDataTable = new DataTable();

                   adapter.Fill(myDataTable);

                   myConnection.Close();

                   foreach (DataRow row in myDataTable.Rows)
                   {       
                       foreach (int item in row.ItemArray) // Loop over the items.
                       {
                           if (item > _SessionNumber)
                           {
                               _SessionNumber = item;
                           }
                       }
                   }
                   _SessionNumber++; // Add on after highes number in database
                       Thread.Sleep(10);


                   SingletonLogger.AddToLog("New SessionId = " + _SessionNumber.ToString(), LogType.Info, LogModule.DB);
               }
               catch (Exception ex)
               {
                   SingletonLogger.AddToLog(ex.ToString(), LogType.Error, LogModule.DB);
               }
           }
       }

        void LogToDbTick_Tick(object sender, EventArgs e)
        {
            if (_LoggingEnabled & _LoggingOn)
            {
                // do logging
               
                var values = new Dictionary<SensorType, float>();

                values.Add(SensorType.Flow1, (int)SingletonCore._PlcVariables.MBFlow1);
                values.Add(SensorType.Flow2, (int)SingletonCore._PlcVariables.MBFlow2);
                values.Add(SensorType.Press1, (int)SingletonCore._PlcVariables.MBPressure1);
                values.Add(SensorType.Press2, (int)SingletonCore._PlcVariables.MBPressure2);
                values.Add(SensorType.RFilter, (int)SingletonCore._PlcVariables.R_Filter);
                values.Add(SensorType.TFilter1, (int)SingletonCore._PlcVariables.T_Filter1);
                values.Add(SensorType.TFilter2, (int)SingletonCore._PlcVariables.T_Filter2);
                values.Add(SensorType.WaterContent, (int)SingletonCore._PlcVariables.MBWaterContent);
                values.Add(SensorType._4um, (int)SingletonCore._PlcVariables.MBConSens4);
                values.Add(SensorType._6um, (int)SingletonCore._PlcVariables.MBConSens6);
                values.Add(SensorType._14um, (int)SingletonCore._PlcVariables.MBConSens14);
                values.Add(SensorType._21um, (int)SingletonCore._PlcVariables.MBConSens21);

                WriteToDb(values);
            }
        }

        #endregion

        #region GET / SET

        public bool LoggingEnabled { get { return _LoggingEnabled; } set { _LoggingEnabled = value; } }
        public bool LoggingOn {get { return _LoggingOn; } set { _LoggingOn = value; } }
        public bool ContinueLogging { get { return _ContinueLogging; } set { _ContinueLogging = value; } }
        public int LoggingInterval { get { return _LoggingInterval; } set { _LoggingInterval = value; } }
        public int SessionNumber { get { return _SessionNumber; } set { _SessionNumber = value; } }
        public string Costumer { get { return _Costumer; } set { _Costumer = value; } }
        


        #endregion
    }
}
