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



//use scale.set_offset(-102079); and scale.set_scale(93.924530);

HX711_7semi loadcell(dataPin, clockPin);

void setup() {
  Serial.begin(115200);
  loadcell.begin();

  loadcell.setScale(scale);  // Set scale factor
  loadcell.tare(50);           // Calibrate zero (tare)
  Serial.println("Tare done. Starting weight measurement...");
}

void loop() {
  serial_receive();

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

void get_force() {
  float samples_weight = 0;
  for ( int i = samples; i; i--){
    samples_weight = samples_weight + loadcell.getWeight();  // Get weight in grams
    //delay(100);
  }
  float average_weight = samples_weight/samples;

  Serial.println(average_weight, 2);
}
