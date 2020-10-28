//By Victor Tchistiak - 2019
// LET OP de bautrate is 230400

#include "BluetoothSerial.h"
BluetoothSerial SerialBT;

String name = "ROCket_RS";
bool connected;

void setup() {
  Serial.begin(115200);
  SerialBT.begin("ROCket_GCM", true); 
  Serial.println("The device started in master mode, make sure remote BT device is on!");
  
  connected = SerialBT.connect(name);

  if(connected) {
    Serial.println("Connected Succesfully!");
  } else {
    while(!SerialBT.connected(10000)) {
      Serial.println("Failed to connect. Make sure remote device is available and in range, then restart app."); 
    }
  }
    if (SerialBT.disconnect()) {
    Serial.println("Disconnected Succesfully!");
  }
  // this would reconnect to the name(will use address, if resolved) or address used with connect(name/address).
  SerialBT.connect();

  Serial.println("INIT Done");
}

void loop() {
  char rec;
  String m_incString;  

  if (SerialBT.available()) 
  {
     // rec = SerialBT.read();
     // m_incString = m_incString + rec;
      Serial.write(SerialBT.read());
  }
  if (m_incString != "" )
  {
      
    //  Serial.print(m_incString);
     // m_incString = "";
     // SerialBT.flush();
  }

  while (Serial.available()) 
  {
      rec = Serial.read();
      m_incString = m_incString + rec;
  }
  if (m_incString != "" )
  {
    
    SerialBT.print(m_incString);
    m_incString = "";
    Serial.flush();
  }
  //delay(20);
 }
