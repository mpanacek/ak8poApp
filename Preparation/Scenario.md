# **Požiadavky**

## Uživateľské

- Tajomník môže zadať a uložiť nový predmet do databázy
- Tajomník môže zadať a uložiť štúdijnú skupinu do databázy
- Tajomník môže vzájomne prepojiť predmety so štúdijnými skupinami
- Tajomník môže zadať všetkých zamestnancov do databázy
- Tajomník môže generovať pracovné štítky a priradzovať ich k zamestnancom
- Tajomník môže presúvať pracovné štítky medzi zamestnancami
- Tajomník je schopný vidieť alokáciu jednotlivých zamestnancov a na základe nej sa rozhodnúť komu priradí ďalší štítok so štúdijnou skupinou
- Tajomník môže odmazať prázdne praconé štítky v prípade poklesu študentov
- Tajomník môže vytvoriť pracovný štítok nespojený so žiadnym predmetom


## Systémové

- Systém po založení skupiny tajomníkom automaticky vygeneruje niekoľko skupiniek ("tried"). Napríklad SWI LS, SWI ZS, atď.
- Systém na základe počtu študentov a veľkostí tried u jednotlivých predmetov vygeneruje pracovné štítky
- Systém po znížení počtu študentov automaticky prepočíta skupiny a aktualizuje štítky
- Systém po zvýšení počtu študentov automaticky prepočíta skupiny a aktualizuje štítky
- Systém automaticky prepočítava pracovné body jednotlivým zamestnancom na základe dát z pracovného štítku
- Systém pri prekročení maximálneho počtu pracovných bodov pri zamestnancovi notifikuje tajomníka


## Nice to have
- Tajomník môže editovať databázu a systém na to automaticky reaguje
- Systém pošle zamestnancovi email o priradených pracovných štítkoch

## Otázky
**Výber ústavu tajomníka?**
**Registrácia tajomníka?**


# **Základná funkcionalita**

## **Pracovný štítok**

Pracovný štítok je cvičenie alebo skupina študentov ktorá je priradená k vyučujúcemu, aby viedol vyučovanie tejto skupiny.
Vytvorené skupinky sa priradia ku jednotlivým predmetom na základe čoho si môžeme určiť koľko má predmet študentov. Z toho sa vytvoria pracovné štítky.

Po priradení pracovného štítku sa pričítajú zamestnancovi body do úväzku. Pracovník nemôže mať viac ako 500 bodov. Ak áno, aplikácia by mala informovať tajomníka.


# Technológie

- **.NET Core**
- **Databáza bude vytvorená pomocou Entity Framework**
- **WPF**
