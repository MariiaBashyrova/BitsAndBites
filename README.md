# BitsAndBites
## Optionale Erweiterungen

Folgende optionale Erweiterungen wurden umgesetzt:

1. **Clean Code / Enums**
   - Verwendung von Enums für Menüpunkte und Bestellstatus
   - Ersetzung von Magic Numbers durch benannte Konstanten

2. **Fehlerbehandlung mit Exceptions**
   - Validierung ungültiger Eingaben
   - Verwendung geeigneter Exceptions bei ungültigen Zuständen und Werten

3. **Erweiterbarkeit / Open-Closed-Prinzip**
   - Erweiterung des Bestellmodells um die Klasse `Gutschein`
   - Die bestehende Bestellberechnung funktioniert auch mit dem neuen Postentyp.
   - Ergänzung automatisierter Tests zur Überprüfung der Gutschein-Funktionalität.