# 🎮 Jump & Run – C# Terminal Game

Ein kleines Jump-&-Run-Spiel in C#, das vollständig in der Konsole gespielt wird. Das Projekt ist im Rahmen des Informatikunterrichts am Beruflichen Gymnasium entstanden.

Der Spieler bewegt sich durch ein Level, springt über Abgründe, sammelt Münzen und versucht, die Zielflagge zu erreichen. Da das Level breiter als das Terminalfenster ist, bewegt sich die Kamera mit dem Spieler.

## ✨ Features

- **Bewegung:** Der Spieler kann nach links und rechts laufen.
- **Springen:** Überwinde Hindernisse und Abgründe mithilfe der Sprungmechanik.
- **Schwerkraft:** Die Spielfigur fällt automatisch nach unten.
- **Kamera-Scrolling:** Der sichtbare Levelausschnitt folgt dem Spieler.
- **Kollisionserkennung:** Erkennt Plattformen, Wände und freie Felder.
- **Münzen:** Sammle Münzen und erhöhe deinen Punktestand.
- **Ziel:** Erreiche die Zielflagge, um das Level abzuschließen.

## 🖥️ Vorschau

```text
                                        
                                        
                                        
                      ###               
                                        
                $$                      
              #####                     
##                                     #
                          ##            
    @                 G   ##            
######  #######################  #######
######  #######################  #######
Muenzen: 4      Leben: 3
```

| Zeichen | Bedeutung |
|:---:|---|
| `@` | Spieler |
| `#` | Boden und Plattformen |
| `$` | Münzen |
| `G` | Gegner |

## 🎮 Steuerung

| Taste | Aktion |
|---|---|
| `A` / `←` | Nach links bewegen |
| `D` / `→` | Nach rechts bewegen |
| `Leertaste` | Springen |
| `Esc` | Spiel beenden |

## 🚀 Installation und Start

### Voraussetzungen

- Windows oder ein kompatibles Betriebssystem
- [Visual Studio](https://visualstudio.microsoft.com/de/) 
- .NET SDK
- C#-Unterstützung

### Projekt starten

1. Repository herunterladen oder klonen:

   ```bash
   git clone https://github.com/Caportabow/JumpAndRun.git
   ```

2. Das Projekt in Visual Studio öffnen.
3. Die Datei `Program.cs` ausführen.
4. Mit `F5` das Spiel starten.

## 🛠️ Technische Umsetzung

Das Spiel basiert auf einer Konsolenanwendung und verwendet unter anderem:

- **C#** als Programmiersprache
- `while`-Schleifen für den Spielloop
- Methoden zur Trennung einzelner Spielfunktionen
- Arrays zur Speicherung von Leveldaten
- 2D-Arrays für die Darstellung der Spielwelt
- Kollisionsabfragen für Bewegung und Schwerkraft
- Tastatureingaben ohne Unterbrechung des Spielloops
- Eine Kamera, die den sichtbaren Ausschnitt des Levels verschiebt

Die Darstellung erfolgt direkt über die Konsolenpositionen. Dadurch wird auf `Console.Clear()` während des Spiels verzichtet, um störendes Flackern zu vermeiden.

## 📚 Entwicklungsplan

Das Projekt ist in drei Etappen mit insgesamt 15 Schritten unterteilt.

### Etappe 1 – Grundspiel

- [x] Schritt 1: Startgerüst zum Laufen bringen
- [x] Schritt 2: Ausschnitt zeichnen
- [x] Schritt 3: Freie Felder erkennen
- [x] Schritt 4: Laufen
- [x] Schritt 5: Schwerkraft
- [x] Schritt 6: Springen
- [ ] Schritt 7: Kamera mitscrollen
- [ ] Schritt 8: Ziel und Loch

### Etappe 2 – Ausbau

- [ ] Schritt 9: Startbildschirm
- [ ] Schritt 10: Schwung beim Springen
- [ ] Schritt 11: Münzen einsammeln
- [ ] Schritt 12: Nochmal spielen

### Etappe 3 – Erweiterungen

- [ ] Schritt 13: Ein Gegner
- [ ] Schritt 14: Leben und Checkpoints
- [ ] Schritt 15: Zeitlimit und eigenes Level

## 💡 Eigene Erweiterungen

Weitere mögliche Funktionen und Ideen:

- Fragezeichen-Blöcke, die beim Anstoßen Münzen freigeben
- Mehrere Gegner mit Arrays
- Farbige Darstellung von Boden, Münzen und Spielfigur
- Vertikales Kamera-Scrolling
- Eigene Level und zusätzliche Hindernisse

---

**Projekt:** Jump & Run  
**Sprache:** C#  
**Plattform:** .NET Console  
**Kontext:** Informatik · Berufliches Gymnasium
