/*
 * HX711 Load Cell Scale Factor Calibration Note
 *
 * The scale factor is used to convert raw ADC values from the HX711
 * into grams.
 *
 * Calibration Steps:
 * 1. Tare the scale (set it to zero with no weight).
 * 2. Place a known weight on the load cell (e.g., 1000g).
 * 3. Observe the raw reading from the HX711.
 * 4. Calculate the scale factor using:
 *      scale_factor = raw_reading / known_weight
 * 5. Replace this value eith scale_factor:
 *      scale.set_scale(scale_factor);
 *
 * Tips:
 * - Use accurate, known weights for calibration.
 * - Make sure the load cell is mounted securely during calibration.
 * - Recalibrate if the physical setup changes.
 */
#include <7semi_HX711.h>

// HX711 pin configuration
const int dataPin = 10;   // DOUT
const int clockPin = 9;  // SCK
float scale = 93.924530;    // Calibration factor (raw units per gram)
int samples = 10;

bool pin_state = false;
const int switchPin = 3;

//use scale.set_offset(-102079); and scale.set_scale(93.924530);

HX711_7semi loadcell(dataPin, clockPin);

void setup() {
  Serial.begin(115200);
  loadcell.begin();

  pinMode(switchPin, INPUT);
  attachInterrupt(digitalPinToInterrupt(switchPin), pin_change, CHANGE);

  loadcell.setScale(scale);  // Set scale factor
  loadcell.tare(50);           // Calibrate zero (tare)
  Serial.println("Tare done. Starting weight measurement...");
}

void loop() {
  serial_receive();

  // delay(100);
  // get_force();

}

void serial_receive() {
  char rx_byte;
  if (Serial.available()) {
    rx_byte = Serial.read();
    switch (rx_byte) {
      case 0x01:
      get_force();
      break;

      case 0x02:
      loadcell.tare(50);
      break;
    }
  }
}

void serial_send(unsigned char cmd_byte, float data) {
  Serial.println(cmd_byte);
  Serial.println(data, 2);
}

void get_force() {
  float samples_weight = 0;
  for ( int i = samples; i; i--){
    samples_weight = samples_weight + loadcell.getWeight();  // Get weight in grams
    //delay(100);
  }
  float average_weight = samples_weight/samples;

  if (pin_state) {
    serial_send(0x02, average_weight);
  }
  else {
    serial_send(0x01, average_weight);
  }
}

void pin_change() {
  if (digitalRead(switchPin)) {
    pin_state = false;
  }
  else {
    pin_state = true;
  }
  
}
