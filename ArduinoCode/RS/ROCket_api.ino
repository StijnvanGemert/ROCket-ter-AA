/*==============================================================================
|* Module File Name: ROCket_api.ino           
|*
|*  version   | Description                                 | date    | author 
|*------------------------------------------------------------------------------
|* v0.01        Initial version                              23-09-2020    SvG
|* v0.02        Added API defines                            25-09-2020    SvG
|*==============================================================================
*/

/*------------------------------------------------------------------------------
|* Notes
|*------------------------------------------------------------------------------
libraries used:
https://github.com/adafruit/Adafruit_BMP280_Library
https://github.com/adafruit/Adafruit_LSM9DS1
https://github.com/adafruit/Adafruit_Sensor

*/


/*------------------------------------------------------------------------------
|* INCLUDES
|*------------------------------------------------------------------------------
*/
#include <Wire.h>
#include <SPI.h>
#include <Adafruit_BMP280.h>
#include <Adafruit_LSM9DS1.h>
#include <Adafruit_Sensor.h> 
#include "BluetoothSerial.h"
/*------------------------------------------------------------------------------
|* DEFINES
|*------------------------------------------------------------------------------
*/
#define MAXLOOP       100

#define START         "##"
#define SEPARATOR     "^"
#define END           "!!"

// Set commando's
#define TIMESTAMP     "TS"
#define ALLSENSOR     "AO"

#define TEMP          "TE"
#define LOCALPRES     "LP"
#define PRESSURE      "PE"
#define HEIGHT        "HE"

#define ACCX          "AX"
#define ACCY          "AY"
#define ACCZ          "AZ"
#define MAGX          "MX"
#define MAGY          "MY"
#define MAGZ          "MZ"
#define GYROX         "GX"
#define GYROY         "GY"
#define GYROZ         "GZ"
#define LSMACC       "LSM1"
#define LSMMAG       "LSM2"
#define LSMGYRO      "LSM3"

// get commando's 
#define GETONE        "GO"
#define GETMULTIPLE   "GM"
#define BATSTAT       "BS"
#define FWVERSION     "FW"
/*------------------------------------------------------------------------------
|* MACROS
|*------------------------------------------------------------------------------
*/


/*------------------------------------------------------------------------------
|* VARIABLES
|*------------------------------------------------------------------------------
*/
// BMP280 SPI
Adafruit_BMP280 bmp; // hardware SPI
Adafruit_Sensor *bmp_temp = bmp.getTemperatureSensor();
Adafruit_Sensor *bmp_pressure = bmp.getPressureSensor();
float BMP280LocalAirPress = 1000.00;

// LSM9DS1 I2C
Adafruit_LSM9DS1 lsm = Adafruit_LSM9DS1();


// sensor events
sensors_event_t temp_event, pressure_event; // BMP280
sensors_event_t a, m, g, temp;              // LSM

// ESP32 bluetooth
BluetoothSerial SerialBT;

// select GO/GM output data
bool set_TS = 1;                                 // Time Stamp

bool set_TE = 1;                                 // Temp
bool set_PE = 1;                                 // barometer
bool set_HE = 0;                                 // calculated height

bool set_AX = 1;                                 // accelorometer x
bool set_AY = 1;                                 // accelorometer y
bool set_AZ = 1;                                 // accelorometer Z
bool set_MX = 1;                                 // magneto x
bool set_MY = 1;                                 // magneto y
bool set_MZ = 1;                                 // magneto z
bool set_GX = 1;                                 // gyro x
bool set_GY = 1;                                 // gyro x
bool set_GZ = 1;                                 // gyro x
/*------------------------------------------------------------------------------
|*  FUNCTIONS
|*------------------------------------------------------------------------------
*/

/* function     : printTo(void)
|* 
|* Description  : Custom print function
|*
|* In/Out       : str: string to print
|*                endline: true to add endline to the string 
*/ 
void printTo(String str, bool endline)
{
  #ifdef DEBUG
    if(endline == true){
      Serial.println(str);
    }else{
      Serial.print(str);
    }
  #endif 
}

/* function     : serialEvent(void)
|* 
|* Description  : Custom print function
|*
|* In/Out       : str: string to print
|*                endline: true to add endline to the string 
*/ 
void serialEvent()
{
  String m_inputString;
  char m_char;

  while (Serial.available())
  {
    m_char = Serial.read();
    m_inputString = m_inputString + m_char;
  }
  if (m_inputString != "")
  {
    Serial.println("Command received is: " + m_inputString);
    HandleSerialBTCommand(m_inputString);
  }
}


/* function     : printTo(void)
|* 
|* Description  : split commands with IndexOf and substring function
|*
|* In/Out       : a_inputString: string to extract into substrings  
*/ 
void HandleSerialBTCommand(String a_inputString)
{

  String m_remainingString = "";
  int m_startIndexOfMessage = 0;
  int m_endIndexOfMessage = 0;
  int m_inputStringLength = 0;
  int m_sanityCheck = 0;
  
  // check for START and END condition of the string and remove the END
  m_inputStringLength = a_inputString.length();																                                // get string lenght 
  m_endIndexOfMessage = a_inputString.indexOf(END) + String(END).length() +1;								                  // find the position of the END characters
  a_inputString.remove(a_inputString.indexOf(END),  m_endIndexOfMessage);									                    // remove the END characters
  
 if (m_inputStringLength - m_endIndexOfMessage == 0)                                                          // check if received commando is correct (START and END both found)
 {                                                                                                            
    if (a_inputString.indexOf(START) >= 0)                                                                    // string START is ok
    {
      do{
        m_sanityCheck++;																					                                            // sanity check
        if (m_startIndexOfMessage == 0)                                                                       // set start index (exeption for the 1st setting in string)
        {
          m_startIndexOfMessage = String(START).length();                                                     // begin form START
        }
        else
        {
          m_startIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_endIndexOfMessage) + 1;                  // begin form SEPARATOR
        }
        
        m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);                        // get end char
        m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              // get substring
        Serial.println("remaining string is : " + (String)m_remainingString);                                 // print string
        processSubString(m_remainingString);                                                                  // do something with the command
      }while((m_endIndexOfMessage > 0) && (m_sanityCheck < MAXLOOP));                                         // loop untill string is proccesed of code goes insane
    }
    else if (a_inputString.indexOf("Test") >= 0)
    {
     // do someting intresting 
    }
    else
    {
      Serial.println("Command not recognized..");
    }
 }
}

void processSubString(String a_inputString)
{
  String m_remainingString = "";
  int m_startIndexOfMessage = 0;
  int m_endIndexOfMessage = 0;
  float m_receivedFloat = 0.0;
  int m_receivedInt = 0;
  
  if (a_inputString.indexOf(GETONE) >= 0)                                                                    // Get a single measurement 
  {
    m_startIndexOfMessage = String(GETONE).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);                   
    doSomePrinting();
  }
  else if (a_inputString.indexOf(GETMULTIPLE) >= 0)                                                           // Get multiple measurements 
  {
    m_startIndexOfMessage = String(GETMULTIPLE).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    for(int index = 0; index < m_receivedInt; index++)
    {
      doSomePrinting();
    }
  }
  else if (a_inputString.indexOf(TIMESTAMP) >= 0)                                                             // set timestamp output on / off
  {
    m_startIndexOfMessage = String(TIMESTAMP).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_TS = m_receivedInt;
  }
  else if (a_inputString.indexOf(TEMP) >= 0)                                                                 // set temperature output on / off
  {
    m_startIndexOfMessage = String(TEMP).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_TE = m_receivedInt;
  }
  else if (a_inputString.indexOf(PRESSURE) >= 0)                                                              // set pressure output on / off
  {
    
  }
  else if (a_inputString.indexOf(HEIGHT) >= 0)                                                                // set height calculation output on / off
  {
    
  }
  else if (a_inputString.indexOf(ACCX) >= 0)                                                                  // set accelero X output on / off                                          
  {
    
  }
  else if (a_inputString.indexOf(ACCY) >= 0)                                                                  // set accelero Y output on / off     
  {
    
  }
  else if (a_inputString.indexOf(ACCZ) >= 0)                                                                  // set accelero Z output on / off     
  {
    
  }
  else
  {
    // error
  }
}



/* function     : setupBMP280(void)
|* 
|* Description  : setup the barometer, BMP280
|*
|* In/Out       : nothing
*/ 
void setupBMP280(void)
{

  printTo("BMP280 Sensor init",1);
  if (!bmp.begin()) {
    printTo("Could not find a valid BMP280 sensor, check wiring!",1);
    while (1) delay(10);
  }

    /* Default settings from datasheet. */
  bmp.setSampling(Adafruit_BMP280::MODE_NORMAL,     /* Operating Mode. */
                  Adafruit_BMP280::SAMPLING_X2,     /* Temp. oversampling */
                  Adafruit_BMP280::SAMPLING_X16,    /* Pressure oversampling */
                  Adafruit_BMP280::FILTER_X16,      /* Filtering. */
                  Adafruit_BMP280::STANDBY_MS_500); /* Standby time. */

  bmp_temp->printSensorDetails();
}


/* function     : setupLSM(void)
|* 
|* Description  : setup the acc,gyro,mag sensor, LSM9DS1
|*
|* In/Out       : nothing
*/ 
void setupLSM(void)
{

  printTo("LSM9DS1 sensor init",1);
    // Try to initialise and warn if we couldn't detect the chip
  if (!lsm.begin())
  {
    printTo("Oops ... unable to initialize the LSM9DS1. Check your wiring!",1);
    while (1);
  }
  printTo("Found LSM9DS1 9DOF",1);
  // 1.) Set the accelerometer range
  lsm.setupAccel(lsm.LSM9DS1_ACCELRANGE_2G);
  //lsm.setupAccel(lsm.LSM9DS1_ACCELRANGE_4G);
  //lsm.setupAccel(lsm.LSM9DS1_ACCELRANGE_8G);
  //lsm.setupAccel(lsm.LSM9DS1_ACCELRANGE_16G);
  
  // 2.) Set the magnetometer sensitivity
  lsm.setupMag(lsm.LSM9DS1_MAGGAIN_4GAUSS);
  //lsm.setupMag(lsm.LSM9DS1_MAGGAIN_8GAUSS);
  //lsm.setupMag(lsm.LSM9DS1_MAGGAIN_12GAUSS);
  //lsm.setupMag(lsm.LSM9DS1_MAGGAIN_16GAUSS);

  // 3.) Setup the gyroscope
  lsm.setupGyro(lsm.LSM9DS1_GYROSCALE_245DPS);
  //lsm.setupGyro(lsm.LSM9DS1_GYROSCALE_500DPS);
  //lsm.setupGyro(lsm.LSM9DS1_GYROSCALE_2000DPS);
  
}

/* function     : setup(void)
|* 
|* Description  : arduino setup
|*
|* In/Out       : nothing
*/ 
void setup() {
  Serial.begin(115200);
  SerialBT.begin("ROCket_RS"); //Bluetooth device name
  setupBMP280();
  setupLSM();

}


/* function     : getBMP280Data(void)
|* 
|* Description  : read the barometer
|*
|* In/Out       : nothing
*/ 
void getBMP280Data(void)
{
  bmp_temp->getEvent(&temp_event);
  bmp_pressure->getEvent(&pressure_event);
}


/* function     : getLSMData(void)
|* 
|* Description  : read the LSM
|*
|* In/Out       : nothing
*/ 
void getLSMData(void)
{
    lsm.read();  /* ask it to read in the data */ 

  /* Get a new sensor event */ 
  lsm.getEvent(&a, &m, &g, &temp); 
}

void doSomePrinting(void)
{
  if (set_TE == 1){
    Serial.print(F("Temperature = "));
    Serial.print(temp_event.temperature);
    Serial.println(" *C");
  }
  if (set_PE == 1){
    Serial.print(F("Pressure = "));
    Serial.print(pressure_event.pressure);
    Serial.println(" hPa");
    Serial.println();
  }

  
  Serial.print("Accel X: "); Serial.print(a.acceleration.x); Serial.print(" m/s^2");
  Serial.print("\tY: "); Serial.print(a.acceleration.y);     Serial.print(" m/s^2 ");
  Serial.print("\tZ: "); Serial.print(a.acceleration.z);     Serial.println(" m/s^2 ");

  Serial.print("Mag X: "); Serial.print(m.magnetic.x);   Serial.print(" uT");
  Serial.print("\tY: "); Serial.print(m.magnetic.y);     Serial.print(" uT");
  Serial.print("\tZ: "); Serial.print(m.magnetic.z);     Serial.println(" uT");

  Serial.print("Gyro X: "); Serial.print(g.gyro.x);   Serial.print(" rad/s");
  Serial.print("\tY: "); Serial.print(g.gyro.y);      Serial.print(" rad/s");
  Serial.print("\tZ: "); Serial.print(g.gyro.z);      Serial.println(" rad/s");

  Serial.println();
}

void doSomeBTPrinting(void)
{
  SerialBT.print("##");
  if (set_TS == 1){
    SerialBT.print("TS"); SerialBT.print(millis()); SerialBT.print("^");
  }
  if (set_TE == 1){
    SerialBT.print("TE"); SerialBT.print(temp_event.temperature); SerialBT.print("^");
  }
  if (set_PE == 1){
    SerialBT.print("PE"); SerialBT.print(pressure_event.pressure); SerialBT.print("^");
  }
  if (set_HE == 1){
  SerialBT.print("PE"); SerialBT.print(bmp.readAltitude(BMP280LocalAirPress)); SerialBT.print("^"); /* Adjusted to local forecast! */
  }
  if (set_AX == 1){
    SerialBT.print("AX");   SerialBT.print(a.acceleration.x);   SerialBT.print("^");
  }
  if (set_AY == 1){
    SerialBT.print("AY");   SerialBT.print(a.acceleration.y);   SerialBT.print("^");
  }
  if (set_AZ == 1){
    SerialBT.print("AZ"); SerialBT.print(a.acceleration.z); SerialBT.print("^");
  }
  
  SerialBT.print("MX"); SerialBT.print(m.magnetic.x);   SerialBT.print("^");
  SerialBT.print("MY"); SerialBT.print(m.magnetic.y);     SerialBT.print("^");
  SerialBT.print("MZ"); SerialBT.print(m.magnetic.z);     SerialBT.print("^");

  SerialBT.print("GX"); SerialBT.print(g.gyro.x);   SerialBT.print("^");
  SerialBT.print("GY"); SerialBT.print(g.gyro.y);      SerialBT.print("^");
  SerialBT.print("GZ"); SerialBT.print(g.gyro.z);      SerialBT.println("^");

  SerialBT.print("##");

}

/* function     : loop(void)
|* 
|* Description  : arduino loop
|*
|* In/Out       : nothing
*/ 
void loop() {
  getBMP280Data();
  getLSMData();
  //doSomePrinting();
  serialEvent();

  //if (Serial.available()) {
 //   SerialBT.write(Serial.read());
 // }
  if (SerialBT.available()) {
    //BTSerialEvent();
    doSomeBTPrinting();
    //SerialBT.flush();
    }
  
  delay(10);
}
