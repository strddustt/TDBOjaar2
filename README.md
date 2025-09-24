# TDBOjaar2
Naam: Aidan Jones

Klas: SD2A

1. Titel en elevator pitch

Titel: 

Elevator pitch, maximaal twee zinnen: Beschrijf kort wat jouw game is en waarom het leuk is om te spelen.

ik ga een tower defense game maken waarbij samenwerking op de voorgrond ligt. je kan varianten van torens kiezen gebaseert op wat het beste werkt


2. Wat maakt jouw tower defense uniek

mijn tower defense gaat meer keuze hebben binnen torens zelf zodat je meer specefiek moet zijn met je keuzes, in plaats van gewoon alles constant toegankelijk hebben


3. Schets van je level en UI

Maak een schets op papier of digitaal en voeg deze afbeelding toe aan je repository. Voeg in deze sectie de afbeelding in.

Je schets bevat minimaal:

    Het pad waar de vijanden over lopen met beginpunt en eindpunt.
    De plaatsen waar torens gebouwd kunnen worden.
    De locatie van de basis of goal die verdedigd moet worden.
    De UI onderdelen geld, wave teller, levens, startknop en pauzeknop.
    Een legenda met symbolen of kleuren voor torens, vijanden, pad, basis en UI.

![alt text](https://github.com/strddustt/TDBOjaar2/blob/main/game%20design/game%20design%20sketch.png?raw=true)


4. Torens

Toren 1 naam, bereik, schade, unieke eigenschap.

gunslinger, 20-70, 1-300, bleed (-speed, +damage resistance, -status effect resistance) / speed buff (als enemy dood is) / dmg buff 

Toren 2 naam, bereik, schade, unieke eigenschap.

mage, 10-35, 3-250, CC (+explosive rng) / freeze / burn

Eventuele extra torens:

5. Vijanden

Vijand 1 naam, snelheid, levens, speciale eigenschap.

assault robot, 3, 550, -50% status effect dmg

Vijand 2 naam, snelheid, levens, speciale eigenschap.

ranger, 2, 1000, stunt torens door op ze te schieten

Eventuele extra vijanden:
6. Gameplay loop

Beschrijf in drie tot vijf stappen wat de speler steeds doet. 
1. speler plaats torens
2. vijanden spawnen in
3. toren vallen vijanden aan
4. speler plaats meer toren

7. Progressie

Leg uit hoe het spel moeilijker wordt naarmate de waves doorgaan. Denk aan sterkere vijanden, kortere tussenpozen, hogere kosten of lagere beloningen.

sterkere vijanden, meer aparte eigenschappen, lageren beloningen

8. Risico’s en oplossingen volgens PIO

    Probleem 1:

    Impact:

    Oplossing:

    Probleem 2:

    Impact:

    Oplossing:

    Probleem 3:

    Impact:

    Oplossing:

9. Planning per sprint en mechanics

Schrijf per sprint welke mechanics jij oplevert in de build. Denk aan voorbeelden zoals vijandbeweging over een pad, torens plaatsen, doel kiezen en schieten, waves starten, UI voor geld en levens, upgrades, jouw unieke feature.

Sprint 1 mechanics: toren aanval, basic UI, toren plaatsen, vijand pathfinding, geld systeem, 1 difficulty

Sprint 2 mechanics: menu, toren keuze scherm, verschillende difficulties (andere vijanden, meer en langere waves, ect.), toren targeting systeem

Sprint 3 mechanics: andere difficulties, infinite mode, levels, toren unlock systeem (gebaseert op levels

Sprint 4 mechanics: optimizing + bug fixes

Sprint 5 mechanics:
10. Inspiratie

Noem een bestaande tower defense game die jou inspireert en wat je daarvan meeneemt of juist vermijdt.

TDX op roblox. interesant concept omdat het aardig wat rare systemen heeft waar je omheen moet werken en je maar de mogelijkheid hebt om 6 torens mee te nemen

11. Technisch ontwerp mini

Lees dit korte voorbeeld en vul daarna jouw eigen keuzes in.

Voorbeeld ingevuld bij 11.1 Vijandbeweging over het pad

    Keuze: Vijanden volgen punten A, B, C en daarna de goal.
    Risico: Een vijand loopt een punt voorbij of blijft hangen.
    Oplossing: Als de vijand dichtbij genoeg is kiest hij het volgende punt. Bij de goal gaat één leven omlaag en verdwijnt de vijand.
    Acceptatie: Tien vijanden lopen van start naar de goal zonder vastlopers en verbruiken elk één leven. Alle tien vijanden bereiken achtereenvolgens elk waypoint binnen één seconde na elkaar.

11.1 Vijandbeweging over het pad

    Keuze: vijanden volgen een vast aangegeven pad via waypoints
    Risico: pad kan niet opgehaald worden, vijanden bewegen niet langs aangegeven punten en staan still
    Oplossing: float voor afstand waypoints zodat er geen rounding fouten ontstaan + reset naar begin als het toch foutgaat
    Acceptatie:

11.2 Doel kiezen en schieten

    Keuze: torens vallen aan gebaseerd op een individueel geselecteerde targeting setting, en vallen aan binnen aangegeven parameters
    Risico: torens kunnen geen target kiezen, fouten bij overgang tussen vijanden, rare situaties waarbij targeting onduidelijk word
    Oplossing: torens hebben een lijst van alle enemies in range, en worden geforceerd eentje te targeten vanuit die lijst. targeting word een enum
    Acceptatie: 

11.3 Waves en spawnen

    Keuze: waves worden van tevoren door mij besloten via een dictionary, en spawnen gebaseerd op tijden die ik meegeef
    Risico: niet genoeg waves, fout binnen het script zorgt ervoor dat niks meer spawnt
    Oplossing: begin vroeg aan wave design, gebruik if else statements om alles nog te laten runnen
    Acceptatie:

11.4 Economie en levens

    Keuze: als enemies het eindpunt bereiken, verliest de speler zoveel levens als de enemy hp had. 1 gold (of andere naam) per damage, towers kunnen zelf geld opbouwen
    Risico: geen idee
    Oplossing:
    Acceptatie:

11.5 UI basis

    Keuze: simpele UI die niet veel in de weg zit. popups om het niet te chaotisch te maken
    Risico: UI is niet heel logisch, kan te veel fout gaan
    Oplossing: goed bug testen
    Acceptatie:
