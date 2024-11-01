const int pins[] = { 2, 3, 4, 5 };
const int buttonAmount = sizeof(pins) / sizeof(pins[0]);
int lastButtonStates[buttonAmount] = {0};

void setup() {
  Serial.begin(9600);
  for (int i = 0; i < buttonAmount; i++) {
    pinMode(pins[i], INPUT);
    lastButtonStates[i] = digitalRead(pins[i]);
  }  
}

void loop() {
  String output = "";
  bool stateChanged = false;
  for (int i = 0; i < buttonAmount; i++) {
    int buttonState = digitalRead(pins[i]);
    if (buttonState != lastButtonStates[i]) {
      stateChanged = true; 
      lastButtonStates[i] = buttonState;
    }
    output += String(buttonState);
    if (i < buttonAmount - 1) {
      output += ","; 
    }
  }
  if (stateChanged) {
    Serial.println(output);
    Serial.flush();
  }
}