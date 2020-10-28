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
#define DEBUG           TRUE

#define FIRMWAREVERSION 0.02f
#define LEDNRA         1          // define LED pins
#define LEDNRB         2 
#define BATPIN         34

#define BMP280         1
#define LSM9DS1        2

#define MAXLOOP       100
#define SPDELAY       10

#define START         "##"
#define SEPARATOR     "^"
#define END           "!!"

// Set commando's
#define TIMESTAMP     "TS"
#define ALLSENSOR     "AO"
#define LEDA          "LA"
#define LEDB          "LB"

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
#define STATUS        "ST"

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
bool set_LEDA = 0;                               // Led status
bool set_LEDB = 0;  

bool set_TE = 1;                                 // Temp
bool set_PE = 1;                                 // barometer
bool set_HE = 1;                                 // calculated height

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
void printTo(String str)
{
  #ifdef DEBUG
      SerialBT.print(str + "\n");
      delay(SPDELAY);
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

  while (SerialBT.available())
  {
    m_char = SerialBT.read();
    m_inputString = m_inputString + m_char;
  }
  if (m_inputString != "")
  {
    SerialBT.flush();
    Serial.println("Command received is: " + m_inputString);
   // delay(SPDELAY);
    HandleSerialBTCommand(m_inputString);
  }
}


/* function     : HandleSerialBTCommand(void)
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
//  Serial.println("length is : " + (String) m_inputStringLength);
//  delay(SPDELAY);
//  Serial.println("end is : " +(String) m_endIndexOfMessage);
//  delay(SPDELAY);
 if (1)//(m_inputStringLength - m_endIndexOfMessage == 0)                                                          // check if received commando is correct (START and END both found)
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
       // Serial.println("remaining string is : " + (String)m_remainingString);                                 // print string
        //delay(SPDELAY);
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
    doSomeBTPrinting();
  }
  else if (a_inputString.indexOf(GETMULTIPLE) >= 0)                                                           // Get multiple measurements 
  {
    m_startIndexOfMessage = String(GETMULTIPLE).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
   // printTo((String)m_receivedInt);
    for(int index = 0; index < m_receivedInt; index++)
    {
      doSomeBTPrinting();
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
  else if (a_inputString.indexOf(LEDA) >= 0)                                                                 // set LedA on / off
  {
    m_startIndexOfMessage = String(LEDA).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    setLed(LEDNRA, m_receivedInt);
    //set_LEDA = m_receivedInt;
  }
    else if (a_inputString.indexOf(LEDB) >= 0)                                                                 // set LedB on / off
  {
    m_startIndexOfMessage = String(LEDB).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    setLed(LEDNRB, m_receivedInt);
    //set_LEDB = m_receivedInt;
  }
  else if (a_inputString.indexOf(BATSTAT) >= 0)                                                                 // set LedB on / off
  {
    m_startIndexOfMessage = String(BATSTAT).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);  
    printTo("##BS" + (String)getBatteryStatus() + "^!!");            
  }
    else if (a_inputString.indexOf(FWVERSION) >= 0)                                                                 // set LedB on / off
  {
    m_startIndexOfMessage = String(FWVERSION).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);  
    printTo("##FW" + (String)FIRMWAREVERSION + "^!!"); 
     
  }
      else if (a_inputString.indexOf(STATUS) >= 0)                                                                 // set LedB on / off
  {
    m_startIndexOfMessage = String(FWVERSION).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);  
    printTo("##FW" + (String)FIRMWAREVERSION + "^BS" + (String)getBatteryStatus() + "^!!"); 
     
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
     m_startIndexOfMessage = String(PRESSURE).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_PE = m_receivedInt;
  }
  else if (a_inputString.indexOf(HEIGHT) >= 0)                                                                // set height calculation output on / off
  {
     m_startIndexOfMessage = String(HEIGHT).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_HE = m_receivedInt;
  }
  else if (a_inputString.indexOf(LOCALPRES) >= 0)                                                                // set height calculation output on / off
  {
     m_startIndexOfMessage = String(HEIGHT).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              

    BMP280LocalAirPress = m_remainingString.toFloat();

  }
  else if (a_inputString.indexOf(ACCX) >= 0)                                                                  // set accelero X output on / off                                          
  {
     m_startIndexOfMessage = String(ACCX).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_AX = m_receivedInt;
  }
  else if (a_inputString.indexOf(ACCY) >= 0)                                                                  // set accelero Y output on / off     
  {
     m_startIndexOfMessage = String(ACCY).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_AY = m_receivedInt;
  }
  else if (a_inputString.indexOf(ACCZ) >= 0)                                                                  // set accelero Z output on / off     
  {
     m_startIndexOfMessage = String(ACCZ).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_TE = m_receivedInt;
  }
  else if (a_inputString.indexOf(MAGX) >= 0)                                                                  // set accelero Z output on / off     
  {
     m_startIndexOfMessage = String(MAGX).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_MX = m_receivedInt;
  }
  else if (a_inputString.indexOf(MAGY) >= 0)                                                                  // set accelero Z output on / off     
  {
     m_startIndexOfMessage = String(MAGY).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_MY = m_receivedInt;
  }
  else if (a_inputString.indexOf(MAGZ) >= 0)                                                                  // set accelero Z output on / off     
  {
     m_startIndexOfMessage = String(MAGZ).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_MZ = m_receivedInt;
  }
  else if (a_inputString.indexOf(GYROX) >= 0)                                                                  // set accelero Z output on / off     
  {
     m_startIndexOfMessage = String(GYROX).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_GX = m_receivedInt;
  }
  else if (a_inputString.indexOf(GYROY) >= 0)                                                                  // set accelero Z output on / off     
  {
     m_startIndexOfMessage = String(GYROY).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_GY = m_receivedInt;
  }
  else if (a_inputString.indexOf(GYROZ) >= 0)                                                                  // set accelero Z output on / off     
  {
     m_startIndexOfMessage = String(GYROZ).length();  
    m_endIndexOfMessage = a_inputString.indexOf(SEPARATOR, m_startIndexOfMessage);
    m_remainingString = a_inputString.substring(m_startIndexOfMessage, m_endIndexOfMessage);              
    m_receivedInt = m_remainingString.toInt();
    set_GZ = m_receivedInt;
  }
  else
  {
    // error
  }
}

void blinkError(int error){
  
}

void sendMsgBack(String a_msgBack)
{
  
}

float getBatteryStatus(void)
{
  float adc_value;
  adc_value = analogRead(BATPIN);
  adc_value = (adc_value * 3.3 ) / (4095);
  return adc_value;
}

void setLed(int ledNr, bool state)
{
  digitalWrite(ledNr, state);
}

/* function     : setupBMP280(void)
|* 
|* Description  : setup the barometer, BMP280
|*
|* In/Out       : nothing
*/ 
void setupBMP280(void)
{

  printTo("BMP280 Sensor init");
  if (!bmp.begin()) {
    printTo("Could not find a valid BMP280 sensor, check wiring!");
    //while (1)
      blinkError(BMP280);
    //delay(10);
    
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

  printTo("LSM9DS1 sensor init");
    // Try to initialise and warn if we couldn't detect the chip
  if (!lsm.begin())
  {
    printTo("Oops ... unable to initialize the LSM9DS1. Check your wiring!");
   // while (1);
    blinkError(LSM9DS1);
  }
  printTo("Found LSM9DS1 9DOF");
  // 1.) Set the accelerometer range
  //lsm.setupAccel(lsm.LSM9DS1_ACCELRANGE_2G);
  lsm.setupAccel(lsm.LSM9DS1_ACCELRANGE_4G);
  //lsm.setupAccel(lsm.LSM9DS1_ACCELRANGE_8G);
  //lsm.setupAccel(lsm.LSM9DS1_ACCELRANGE_16G);
  
  // 2.) Set the magnetometer sensitivity
  //lsm.setupMag(lsm.LSM9DS1_MAGGAIN_4GAUSS);
  lsm.setupMag(lsm.LSM9DS1_MAGGAIN_8GAUSS);
  //lsm.setupMag(lsm.LSM9DS1_MAGGAIN_12GAUSS);
  //lsm.setupMag(lsm.LSM9DS1_MAGGAIN_16GAUSS);

  // 3.) Setup the gyroscope
  //lsm.setupGyro(lsm.LSM9DS1_GYROSCALE_245DPS);
  lsm.setupGyro(lsm.LSM9DS1_GYROSCALE_500DPS);
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
  //adcAttachPin(BATPIN);
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
    printTo(F("Temperature = "));
    printTo((String)temp_event.temperature);
    printTo(" *C\n");
    printTo(F("Pressure = "));
    printTo((String)pressure_event.pressure);
    printTo(" hPa\n\n");
 
  
  printTo("Accel X: "); printTo((String)a.acceleration.x); printTo(" m/s^2");
  printTo("\tY: "); printTo((String)a.acceleration.y);     printTo(" m/s^2 ");
  printTo("\tZ: "); printTo((String)a.acceleration.z);     printTo(" m/s^2 \n ");

  printTo("Mag X: "); printTo((String)m.magnetic.x);   printTo(" uT");
  printTo("\tY: "); printTo((String)m.magnetic.y);     printTo(" uT");
  printTo("\tZ: "); printTo((String)m.magnetic.z);     printTo(" uT\n");

  printTo("Gyro X: "); printTo((String)g.gyro.x);   printTo(" rad/s");
  printTo("\tY: "); printTo((String)g.gyro.y);      printTo(" rad/s");
  printTo("\tZ: "); printTo((String)g.gyro.z);      printTo(" rad/s\n\n");

}

void doSomeBTPrinting(void)
{
  String outputString = "##"; 
  getBMP280Data();
  getLSMData();
  if (set_TS == 1){
    outputString = outputString + "TS" + millis() + "^";
  }
  if (set_TE == 1){
    outputString = outputString + "TE" + temp_event.temperature + "^";
  }
  if (set_PE == 1){
    outputString = outputString + "PE" + pressure_event.pressure + "^";
  }
  if (set_HE == 1){
    outputString = outputString + "HE" + bmp.readAltitude(BMP280LocalAirPress) + "^";
  }
  if (set_AX == 1){
    outputString = outputString + "AX" + a.acceleration.x + "^";
  }
  if (set_AY == 1){
    outputString = outputString + "AY" + a.acceleration.y + "^";
  }
  if (set_AZ == 1){
    outputString = outputString + "AZ" + a.acceleration.z + "^";
  }
  if (set_MX == 1){
    outputString = outputString + "MX" + m.magnetic.x + "^";
  }
  if (set_MY == 1){
    outputString = outputString + "MY" + m.magnetic.y + "^";
  }
  if (set_MZ == 1){
    outputString = outputString + "MZ" + m.magnetic.z + "^";
  }
  if (set_GX == 1){
    outputString = outputString + "GX" + g.gyro.x + "^";
  }
  if (set_GY == 1){
    outputString = outputString + "GY" + g.gyro.y + "^";
  }
  if (set_GZ == 1){
    outputString = outputString + "GZ" + g.gyro.z + "^";
  }
  outputString.remove(outputString.length());
  outputString = outputString + "!!";
    
  printTo(outputString);
}

/* function     : loop(void)
|* 
|* Description  : arduino loop
|*
|* In/Out       : nothing
*/ 
void loop() {
 // getBMP280Data();
 // getLSMData();
  //doSomePrinting();
  //serialEvent();

  //if (Serial.available()) {
 //   SerialBT.write(Serial.read());
 // }
  if (SerialBT.available()) {
    //BTSerialEvent();
    //Serial.print("JJA");
    serialEvent();
    //doSomeBTPrinting();
    SerialBT.flush();
    }
   //doSomeBTPrinting();
  delay(2);
}
