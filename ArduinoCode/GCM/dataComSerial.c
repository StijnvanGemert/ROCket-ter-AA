// this example uses 3 string operator
// indexOf     : https://www.arduino.cc/reference/en/language/variables/data-types/string/functions/indexof/
// length()    : https://www.arduino.cc/en/Tutorial/StringLength
// substring() : https://www.arduino.cc/reference/en/language/variables/data-types/string/functions/substring/

#define SWITCHPIN			2
#define LEDPIN				13


#define START 				"##"
#define END 				"!!"
#define LEDGREEN 			"LG"
#define SWITCH				"SW"


void setup()
{
  Serial.begin(115200);
  pinMode(SWITCHPIN, INPUT_PULLUP);
  pinMode(LEDPIN, OUTPUT);
}


// get the full string from the serial bus
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
    Serial.println("Command received in Arduino is: " + m_inputString);
    HandleSerialCommand(m_inputString);
  }
}



// check if the string is complete with a START and END tag and make a substring from the commando 
void HandleSerialCommand(String a_inputString)
{

  String m_subString = "";
  int m_startIndexOfMessage = 0;
  int m_inputStringLength = 0;
  int m_sizeOfSub = 0;
  int m_startOfSub = 0;
  int m_endOfSub = 0;
  int m_endOfString = 0;

  m_inputStringLength = a_inputString.length();
  m_endOfString = a_inputString.indexOf(END) + String(END).length();

  if (m_inputStringLength == m_endOfString)
  {
    Serial.println("we found a END sign");
  	if (a_inputString.indexOf(START) == 0)
  	{
      Serial.println("we found a START sign");
      m_startOfSub = String(START).length();
      m_endOfSub = a_inputString.indexOf(END);
      m_subString = a_inputString.substring(m_startOfSub, m_endOfSub);
	  ProcessSubString(m_subString);
  	}
  }
}


// process the substring, look for a valid commando and execute the commando
void ProcessSubString(String a_inputString)
{
  String m_receivedValueInString ="";
  int m_opCodeOffset = 0;
  int m_sizeOfSubString = 0;
  int m_receivedInt = 0;
  if (a_inputString.indexOf(LEDGREEN) == 0)
  {
  	Serial.println("do something with the green led");
    m_sizeOfSubString = a_inputString.length();												
    m_opCodeOffset = String(LEDGREEN).length();     
    m_receivedValueInString = a_inputString.substring(m_opCodeOffset, m_sizeOfSubString);
    Serial.println("Value in String format received is: " + m_receivedValueInString);
    if (m_receivedValueInString == "")
    {
      Serial.println("Get");
    }
    else
    {
      Serial.println("Set");
      m_receivedInt = m_receivedValueInString.toInt();
      SetGreenLed(m_receivedInt);
    }
  }
  else if (a_inputString.indexOf(SWITCH) == 0)
  {
  	Serial.println("do something with the swithc");
    m_sizeOfSubString = a_inputString.length();												
    m_opCodeOffset = String(SWITCH).length();     
    m_receivedValueInString = a_inputString.substring(m_opCodeOffset, m_sizeOfSubString);
    Serial.println("Value in String format received is: " + m_receivedValueInString);
    if (m_receivedValueInString == "")
    {
      Serial.println("Get");
      Serial.println(ReadSwitch());
    }
    else
    {
      Serial.println("Set");
      m_receivedInt = m_receivedValueInString.toInt();
      SetGreenLed(m_receivedInt);
    }
  }
}

void loop()
{
  delay(10); // Delay a little bit to improve simulation performance
}


void SetGreenLed(int state)
{
   if (state == 0) {
    digitalWrite(13, LOW);
  } else {
    digitalWrite(13, HIGH);
  } 
}

bool ReadSwitch(void)
{
 return digitalRead(SWITCHPIN); 
}
}