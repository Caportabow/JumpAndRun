using System;
using System.Threading;

class Program
{
    // ================= Daten des Spiels =================
    // # = Boden/Block, | und F = Ziel-Fahne, Leerzeichen = Luft
    static string[] level = {
        "                                                                                                              ",
        "                                                                                                              ",
        "                                                                                                              ",
        "                                      ###                                                                |F   ",
        "                                                               ###                                       |    ",
        "                                                                                                         |    ",
        "                              #####                                                 #####                |    ",
        "              ####                                     #####          ##                                 |    ",
        "                                          ##                        ####                                 |    ",
        "          ##                              ##                        ####                    ##           |    ",
        "######################  #######################  ##########################  #################################",
        "######################  #######################  ##########################  #################################"
    };
    static int sichtBreite = 40;      // so viele Spalten sieht man
    static int kameraX = 0;           // erste sichtbare Spalte des Levels
    static int spielerX = 2;
    static int spielerY = 9;
    static int sprung = 0;            // wie viele Schritte es noch nach oben geht

    // ================= Werkzeugkasten – einfach übernehmen =================

    // Terminal vorbereiten: Cursor ausblenden, Bildschirm leeren
    static void Vorbereiten()
    {
        Console.CursorVisible = false;
        Console.Clear();
    }

    // Ganzen Bildschirm leeren (flackert – nicht in jedem Durchlauf benutzen!)
    static void Leeren()
    {
        Console.Clear();
    }

    // Text an Spalte x, Zeile y schreiben (links oben ist 0, 0)
    static void Schreibe(int x, int y, string text)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(text);
    }

    // Wie Schreibe, aber in Farbe, z. B. ConsoleColor.Yellow
    static void SchreibeFarbig(int x, int y, string text, ConsoleColor farbe)
    {
        Console.ForegroundColor = farbe;
        Console.SetCursorPosition(x, y);
        Console.Write(text);
        Console.ResetColor();
    }

    // Gedrückte Taste holen, OHNE zu warten.
    // Wurde nichts gedrückt, kommt ConsoleKey.NoName zurück.
    static ConsoleKey TasteOhneWarten()
    {
        ConsoleKey taste = ConsoleKey.NoName;
        while (Console.KeyAvailable)          // alle wartenden Tasten abholen –
        {                                     // die zuletzt gedrückte zählt
            taste = Console.ReadKey(true).Key;
        }
        return taste;
    }

    // Warten, bis eine Taste gedrückt wird, und sie zurückgeben
    static ConsoleKey TasteAbwarten()
    {
        return Console.ReadKey(true).Key;
    }

    // Programm ms Millisekunden anhalten (1000 ms = 1 Sekunde)
    static void Warte(int ms)
    {
        Thread.Sleep(ms);
    }

    // Zufallszahl von min bis max (beide eingeschlossen)
    static Random zufall = new Random();
    static int Zufall(int min, int max)
    {
        return zufall.Next(min, max + 1);
    }

    // Textzeilen in ein 2D-Array umwandeln: karte[x, y]
    static char[,] KarteLaden(string[] zeilen)
    {
        int breite = zeilen[0].Length;
        int hoehe = zeilen.Length;
        char[,] karte = new char[breite, hoehe];
        for (int y = 0; y < hoehe; y++)
        {
            for (int x = 0; x < breite; x++)
            {
                karte[x, y] = zeilen[y][x];
            }
        }
        return karte;
    }

    // ================= Deine Funktionen =================

    static void ZeichneBild()
    {
        // Schritt 2
        for (int y = 0; y < level.Length; y++)
        {
            string zeile = "";
            for (int x = 0; x < level[0].Length; x++)
            {
                if (x == spielerX && y == spielerY)
                {
                    zeile = zeile + "@";
                }
                else
                {
                    zeile = zeile + level[y][x];
                }
            }
            Schreibe(0, y, zeile.Substring(kameraX, sichtBreite));
        }
    }

    static bool IstFrei(int x, int y)
    {
        if (x < 0 || x >= level[0].Length || y < 0 || y >= level.Length)
        {
            return false;
        }

        return level[y][x] == ' ';
    }

    // ================= Das Spiel =================

    static void Spielen()
    {
        bool spielVorbei = false;
        while (!spielVorbei)
        {
            // 1. Eingabe
            ConsoleKey taste = TasteOhneWarten();
            if (taste == ConsoleKey.Escape)
            {
                spielVorbei = true;
            }
            // Schritt 4: laufen
            if ((taste == ConsoleKey.LeftArrow) && IstFrei(spielerX - 1, spielerY))
            {
                spielerX--;
            }
            if ((taste == ConsoleKey.RightArrow) && IstFrei(spielerX + 1, spielerY))
            {
                spielerX++;
            }
            
            // Schritt 6: springen
            if (taste == ConsoleKey.UpArrow && sprung == 0 && !IstFrei(spielerX, spielerY + 1))
            {
                sprung = 3;
            }

            if (sprung > 0)
            {
                if (IstFrei(spielerX, spielerY - 1))
                {
                    spielerY--;
                }

                sprung--;
            }

            // 2. Aktualisieren
            // Schritt 5: Schwerkraft
            if (sprung == 0 && IstFrei(spielerX, spielerY + 1))
            {
                spielerY++;
            }
            
            
            // Schritt 7: Kamera    Schritt 8: Ziel und Loch

            // 3. Zeichnen
            ZeichneBild();

            // 4. Warten
            Warte(80);
        }
    }

    static void Main(string[] args)
    {
        Vorbereiten();
        // Schritt 9: Startbildschirm
        Spielen();
        Schreibe(0, level.Length + 2, "Taste druecken ...");
        TasteAbwarten();
    }
}
