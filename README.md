# Úvodní strana/Domů
- header (nemění se)
  - navigace (sticky možná)
    - domů
    - virtuální adopce
    - mazlíčci (promyslet)
    - aktuality
    - kontakt
    - ztráty a nálezy
    - informace
    - moje adopce 
  - přihlášení logo
  - jazyk
- body
  - přivítání, o co jde, kde jsme, obrázky
  - jak nám pomoci
  - nově příchozí
  - (novinky)
- footer (nemění se) -> kontakty/nějaké odkazy/info 

# Přihlášení
1. admin
  - může měnit hesla
  - spravovat role
  - _přístup k logům akcí pracovníků (třeba pro odměnu za aktivitu a správu)_
  - _+ to co pracovník_
3. pracovník
  - přidávat a odebírat mazlíčky
  - měnit informace
  - _(+ spravovat novinky)_
  - _+ to co zákazník_
4. zákazík
  - adoptovat
  - zobrazit adaptované mazlíčky, vidět informace
5. návštěvník
  - **nepřihlášený** uživatel
  - pouze zobrazovat informace a mazlíčky k adopci

# Virtuální adopce
- body
  -podmínky základní
  -informace (odkaz) + kompletní podmínky
  -kontaktní formulář + vybraný mazlíček
  -_(seznam mazlíčků)_
  -donate/_platební brána_ (QR kód)

# Mazlíčci
- body
  - informace o mazlíčcíh
    - (animace = obrázek se jménem -> najetí obrázek do pozadí, jméno nahoru a zobtazí se informace)
  - stránky po př 9 mazlíčcích a pak možnost dalšího načtení
  - filtr na vyhledávání
  - na obr mazlíčka proklik na více infa

# Ztráty a nálezy
- body
  - formulář  

# Moje adopce
- body
  - výpis mazlíčku, které uživatel aktivně podporujete
  - _(historie adoptací)_

# Databáze + přidat obrázky/schéma
- **pets:** informace o mazlíčcích
- **users:** informace o uživatelých (mimo návštěvníky)
- _**language:** překlady webových elementů (pořešit)_
- **log:** aktivity pracovníků
- **users&pets:** propojení tabulky uživatelů a petů

[DB Scheme Users & Pets](./UsersAndPetsScheme.png)

