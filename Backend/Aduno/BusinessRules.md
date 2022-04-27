# Business Rules for Entities

Rule | Operation | Condition | Operation | Content
---|---|---|---|---
R1|WENN|ein Raum erstellt wird
||||DANN|muss eine **Bezeichnung gegeben** sein
||||UND|eine **Raumnummer gegeben** sein
||||UND|ein **Stockwerk gegeben** sein
||||UND|einer **validen/existierenden Organisation** zugeteilt sein (Id gegeben)
R2|WENN|ein Raum gel�scht wird
||||DANN|m�ssen vorher alle zu dem Raum **zugeh�rigen Timestamps gel�scht** werden
||||UND|(*der "Auftraggeber" muss zum L�schen authorisiert sein**)
|
|U1|WENN|ein User erstellt wird
||||DANN|muss eine neue GUID (Globally Unique Identification Number) generiert werden
||||UND|...