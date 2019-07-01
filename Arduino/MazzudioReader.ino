#include <MFRC522.h>
#include <SPI.h>
#include <Wire.h>



MFRC522 mfrc522(10, 9); 
MFRC522::MIFARE_Key readKey;
MFRC522::MIFARE_Key writeKey;
const int BUZZER_PIN = 7;
 

byte _blankBuffer[18] = {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
boolean _isStart = false;
byte _commandCode[16] = {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};


static void beep() {
  digitalWrite (BUZZER_PIN, 0);
  delay (80);
  digitalWrite (BUZZER_PIN, 255);
}

static void beep2() {
  digitalWrite (BUZZER_PIN, 0);
  delay (20);
  digitalWrite (BUZZER_PIN, 255);
  delay (60);
  digitalWrite (BUZZER_PIN, 0);
  delay (80);
  digitalWrite (BUZZER_PIN, 255);
}

void setup() {
  Serial.begin(9600);
  SPI.begin(); // Init SPI bus
  mfrc522.PCD_Init(); // Init MFRC522 

  while (!Serial) {
    ; // wait for serial port to connect. Needed for Leonardo only
  } 
  
  pinMode (BUZZER_PIN, OUTPUT);
  delay(80);
  digitalWrite (BUZZER_PIN , 255); 
}

void loop() {
  // put your main code here, to run repeatedly:
  int avalableBytes = Serial.available();
  if (avalableBytes > 0) // ตรวจสอบว่ามีข้อมูลเข้ามาหรือไม่
  {
    Serial.readBytes(_commandCode, avalableBytes);
    if(avalableBytes == 1){
      switch(_commandCode[0]){
        case 0x07 : // Start async reader  
          _isStart = true;
          break;
        case 0x08 : // Stop async reader. 
          _isStart = false;
          break;
      }
    }
  }
  
  if(_isStart == true){
    if ( ! mfrc522.PICC_IsNewCardPresent())
      return;
    if ( ! mfrc522.PICC_ReadCardSerial())
      return;
    MFRC522::PICC_Type piccType = mfrc522.PICC_GetType(mfrc522.uid.sak);
  
    // Check for compatibility
    if (piccType != MFRC522::PICC_TYPE_MIFARE_MINI
        &&  piccType != MFRC522::PICC_TYPE_MIFARE_1K
        &&  piccType != MFRC522::PICC_TYPE_MIFARE_4K) {
      return;
    }
    byte snBuffer[16];
    snBuffer[0] = 0xFA;
    snBuffer[1] = mfrc522.uid.size;
    byte chk = 0;
    for(int i = 0; i < mfrc522.uid.size; i++){
      snBuffer[i + 2] = mfrc522.uid.uidByte[i];
      chk += snBuffer[i + 2];
    }
    snBuffer[2 + mfrc522.uid.size] = chk; 
    Serial.write(snBuffer, mfrc522.uid.size + 3);
  
    // Halt PICC
    mfrc522.PICC_HaltA();
    // Stop encryption on PCD
    mfrc522.PCD_StopCrypto1();
    delay(50);
    return;
    
  }
  delay(20);
}
