### Skupinka

- Skratka – string - SWI
- Názov - string - Softvérové inžinierstvo
- Ročník – int – 4
- Semester – enum – LS
- Počet študentov – int – 36
- Forma štúdia – enum – P
- Typ štúdia – enum – Bc.
- Jazyk – enum – cz


### Predmet

- Skratka (jednoznačný identifikátor) – string – AP8PO
- Názov - string - Pokročilé programovanie
- Počet kreditov - int - 5
- Počet týždňov – int – 14 default (u kombinovaného štúdia, vždy 1)
- Hodiny prednášiek – int – 1
- Hodiny cvičení – int – 3
- Hodiny seminárov – int – 2
- Spôsob zakončenia – enum – z, zk
- Jazyk – enum – cz
- Veľkosť triedy – int – 24 (default 24, často 12, 0 u kom)
- Zoznam skupín – List<Skupinka> - množina referencií na 1)


### Zamestnanec 

- Meno – string – Pavel
- Priezvisko – string - Vařacha
- Celé meno – Meno + Priezvisko – Pavel Vařacha
- Pracovný e-mail – string – varacha@utb.cz
- Súkromý e-mail – string – pavel.varacha@gmail.com
- Pracovný telefón - string - +420 576 035 186
- Súkromný telefóon - string - 777567135
- Pracovné body bez angličtiny – int – 526 (Toto nebude vlastnosť, ale metóda.)
- Pracovné body – int – 767 (Toto nebude vlastnosť, ale metóda.)
- Doktorant – bool - false
- Úväzok – double – 0 až 1 (0 zamestnanec na dohodu, nebo doktorant, inak percento)
- Zoznam štítkov – List<Pracovný štítok> - množina referencií na 4


### Pracovný štítok

- Názov – string – Cvičenie AP8PO 1
- Zamestnanec – referencia na 4) – (Pavel Vařacha) alebo null
- Predmet – referencia na 2) – (AP8PO) alebo null 
- Typ – enum – prednáška, cvičenie, seminár, zápočet, klasifikovaný zápočet, skúška
- Počet študentov – int – 11
- Počet hodín – int – 0 u z, zk, kl, pretože se počíta na človeka, číslo u p, c, s, (napr. 2)
- Počet týždňov – int – 0 u z, zk, kl, pretože se počíta na človeka, číslo u p, c, s, (napr. 14)
- Jazyk – enum – cz
- Počet bodov za pracovný štítok – int – 12.5 (Toto nebude vlastnosť, ale metóda.)



### Váhy pracovních bodů

(Doplňujúci model, ktorý se po spustení aplikácie načíta z XML, alebo databázy, niekam do GlobalConfig.)

- Hodina prednášky – double – 1,8
- Hodina cvičenia – double – 1,2
- Hodina semináre – double – 1,2
- Hodina prednášky anglicky – double – 2,4
- Hodina cvičenia anglicky – double – 1,8
- Hodina semináre anglicky – double – 1,8
- Udelenie jedného zápočtu – double – 0,2
- Udelenie jedného klasifikovaného zápočtu – double – 0,3
- Udelenie jednej skoúšky – double – 0,4
- Udelenie jedného zápočtu anglicky – double – 0,2
- Udelenie jedného klasifikovaného zápočtu anglicky – double – 0,3
- Udelenie jednej skoúšky – anglicky - double – 0,4

