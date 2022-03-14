# reSign 

## Unsere Idee
Das reSign Team möchte, ein einfach zu bedienendes Fast-Check-In-System (FCIS) für viele verschiedene Anwendungsfälle bereitstellen. Mit unserem Projekt wollen wir das Zeitalter des Kartenschleppens und Passwort merken beenden. Mit einer einfachen Handbewegung wird ein QR-Code, mit ihrem mobilen Endgerät gescannt und dadurch den User automatisch angemeldet. Die Idee soll Kunden aber auch den Usern dieser Applikation wichtige Zeit und Geld sparen und somit die Effizienz im Unternehmen steigern.

### Anwendungsfälle

Was ist ein gutes System ohne Anwendungsfall, nicht brauchbar. Deshalb werden nun drei sehr unterschiedliche Anwendungsfälle gezeigt die zeigen, dass es auch für das ReSign-Produkt durch aus einen vielfältigen Markt gibt.

***Krankenhaus***

Eine Studie hat gezeigt, dass Ärzte in Krankenhäusern mit An/Abmelden in einer 10-Stunden Schicht bis zu 45 Minuten verlieren. Das große Problem ist, dass in Krankenhäusern ein reger Verkehr an PC herrscht, da sich ein Arzt in jedem Zimmer oder zumindest in jeder Abteilung neu anmelden muss um streng vertrauliche Patientendaten einzusehen. Wenn dieser Prozess auf ein Minimum verkleinert werden könnte, würde es den Menschen die behandelt werden müssen sehr weiterhelfen da sich die Ärzte dann nur auf sie konzentrieren könnten und die Ärzte hätten fast eine Stunde weniger Aufwand und mehr Zeit für Pausen oder mehr Zeit Patienten zu helfen. Für solchen Systemen mit sehr hohen Sicherheitsstandart werden wir in nächster Zeit eine höhere Sicherheitsstruktur anbieten.

***Schule***

Ein weiterer Anwendungsfall wäre eine Schule. Jeden Morgen müssen alle Schüler von einer Lehrkraft als anwesend eigetragen werden. Dieser Vorgang kann einige Minuten dauern, Minuten die kostbare Unterrichtszeit in Anspruch nehmen. Diese Vorgang könnte man ganz einfach mit unserem FCIS-System bereinigen. Jeder Schüler registriert sich einfach einmal und ist damit nun registriert. Sobald er also den Raum betritt, kann er mit Hilfe eines QR-Code ganz einfach auf die Seite weitergeleitet werden, wo der User dann automatisch als anwesend für den Tag eingetragen ist. Der Lehrer übernimmt dann einfach diese Daten und kann dadurch gleich mit dem Unterrichten anfangen.

***Unternehmen***

Ein weiterer Anwendungsfall ist eine Firma mit vielen Arbeitern. Oftmals wird bei einer herkömmlichen Stempeluhr ein Chip oder eine Karte benötigt. Diese könnte im schlimmsten Fall abhandenkommen und noch dazu dauert der Vorgang noch länger, wenn man sich verifizieren muss. Mit unserem FCIS-System können wir eine schnellen und einfachen Einstempelsystem garantieren und somit auch Frust und Zeit bei den Usern sparen

### Fast-Check-In-System (FCIS)
Das Fast-Check-In-System kurz FCIS ermöglicht das leichte und schnelle An/Abmelden eines Users. Durch einen QR-Code wird man auf die Website weitergeleitet, wo man dann bei Registrierung sofort angemeldet wird. Wenn man sich noch nicht registriert hat, wird man Aufgerufen den Anmeldeprozess zu absolvieren und dadurch dann das Fast-Check-In-System einfach und schnell benützen zu können.

**Funktionalität**

![Alt-Text](https://github.com/steinmax/reSign/blob/main/Resources/FCIS.png)

Das Backend und der REST Service wir in C# verfasst und die Datenbank(PostgreSQL).
Das alles läuft auf der Oracle VM. Die Schnittstellen kommunizieren mit dem REST Service und die Endpoints werden so angesteuert.

***Token Generierung***

Da der QR-Code ja nur ein Link zu der Website ist, wo man dann beim Aufrufen registriert wird, könnte man einfach sobald man einmal den Link hat gemütlich von zu Hause anmelden. Das ist nicht Sinn der Sache und somit hat sich das ReSign-Team eine Lösung erarbeitet. Mit sogenannten Tokens werden nun immer wieder neue QR-Codes erstellt Bsp: (https://resign.byiconic.at?t=709e3f82). Sie sind jedes Mal Unique und somit wird das System immer nur den Link mit dem aktuellen Token zum Anmelden zulassen. Damit können wir garantiert, dass sich der User sich direkt bei der Anmeldestation befindet. Nach jeder Anmeldung wird ein neuer Token generiert und ist damit dann der neue aktuelle Token.

Der zweite Token der generiert wird ist beim Anlegen eines neuen Users. Dieser Token ist länger da er das System nicht verlangsamt. Jedes Mobile-Endgerät bekommt so einen Bsp: (83ea1b86-75b4-4507-a5af-e27a50ebae0a) Unique-Token und wird damit automatisch einem User zugewiesen.

### Vorteile dieser Applikation
- Aufmerksamkeit nicht mehr vernachlässigt
- Keine Anmeldekarten notwendig
- Keine Passwörter notwendig
- Anmeldung pfeilschnell möglich
- Einfache Implementierung in Ihrem Unternehmen

### Organisation
**Product Owner**
- Prof. Hammer 
- Prof. Aberger

**Projektleiter:**
- Imsirovic Benjamin

**Team:** 
- Edalathkah Arsham
- Rausch-Schott Simon
- Siegl Maximilian


[![Docker Image CI](https://github.com/steinmax/reSign/actions/workflows/docker-image.yml/badge.svg)](https://github.com/steinmax/reSign/actions/workflows/docker-image.yml)
