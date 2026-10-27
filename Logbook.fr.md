# Journal de bord — Projet Meadowbound

Développement d'un jeu de farming en monde ouvert 2.5D avec C# et MonoGame

## Jour 1 — Analyse du besoin et définition du projet

**Temps de travail**: 
180 min / 3 heures

**Objectif**:
Cadrage / Besoin et périmètre

### 1. Objectif de la journée

Cette première journée a été consacrée à la définition des bases du projet Meadowbound. L'objectif était de préciser le besoin auquel répond le jeu, les fonctionnalités envisagées, les technologies à utiliser et les principales étapes de développement.

Une attention particulière a été portée à la définition d'un MVP (Minimum Viable Product), afin de limiter le périmètre initial et de disposer d'une première version jouable avant d'envisager des fonctionnalités plus avancées.

### 2. Déroulement de la journée

| Activité                  | Travail effectué                                                                   | Durée   |
| ------------------------- | ---------------------------------------------------------------------------------- | ------- |
| Analyse du besoin         | Définition de la situation, des objectifs et du périmètre du projet.               | 30 min  |
| Définition du MVP         | Identification et priorisation des fonctionnalités indispensables.                 | 35 min  |
| Conception de la solution | Réflexion sur les écrans, la perspective 2.5D, l'architecture et les technologies. | 40 min  |
| Organisation du projet    | Identification des étapes de développement, des risques et des besoins de gestion. | 30 min  |
| Documentation             | Structuration du document, rédaction et identification des sources.                | 25 min  |
| Bilan et préparation      | Synthèse des décisions et définition des travaux à poursuivre.                     | 20 min  |
| Total                     |                                                                                    | 180 min |

### 3. Travaux réalisés

Le projet a été défini comme un jeu de simulation agricole en monde ouvert, développé en C# avec MonoGame. Le joueur pourra développer sa ferme, cultiver des plantes et explorer un environnement représenté en 2.5D.

Le périmètre initial a été orienté vers les mécaniques essentielles : affichage de la carte, déplacements, caméra, collisions, agriculture, inventaire et sauvegarde. Les fonctionnalités secondaires, comme le commerce, les personnages non joueurs et les systèmes avancés, ont été réservées aux versions ultérieures.

Les premières orientations techniques ont également été définies. MonoGame permettra de gérer le rendu et les entrées du joueur, tandis que Git et GitHub serviront respectivement au suivi des versions et à l'organisation du travail.

Enfin, les principaux risques ont été identifiés, notamment la gestion de la perspective 2.5D, les collisions, la complexité de l'architecture et le risque d'élargissement excessif du périmètre.

### 4. Résultats obtenus

- Définition du concept général de Meadowbound.
- Première délimitation du périmètre du projet.
- Identification et priorisation des fonctionnalités du MVP.
- Définition des premières orientations techniques.
- Élaboration d'une première estimation du planning.
- Mise en place de la base de la documentation technique.

### 5. Difficultés et points de vigilance

La principale difficulté concerne l'équilibre entre les ambitions du jeu et le temps disponible. Un jeu de farming comprend de nombreux systèmes qui dépendent les uns des autres. Il est donc nécessaire de construire une base technique stable avant de développer les fonctionnalités plus complexes.

La perspective 2.5D représente également un point de vigilance, notamment pour la gestion des collisions et l'affichage des éléments selon leur profondeur.

Le planning reste provisoire : la durée totale du projet devra être précisée en fonction de l'avancement et des difficultés rencontrées.

### 6. Bilan de la journée

Cette première journée a permis de définir une direction claire pour le projet et de poser les bases du cahier des charges. Le MVP constitue désormais la référence pour les premières étapes du développement.

Les choix effectués devront être confirmés progressivement par des essais techniques. Il reste notamment à organiser l'environnement de développement, à structurer le dépôt GitHub et à détailler les tâches nécessaires à la réalisation du jeu.

### 7. Prochaines étapes

- Définir la méthodologie de gestion du projet.
- Préparer l'environnement de développement.
- Organiser le dépôt GitHub.
- Décrire et justifier les choix techniques.
- Transformer les fonctionnalités en tâches distinctes.
- Commencer la planification détaillée.

## Jour 2 — Méthodologie, environnement technique et planification

**Temps de travail**:
180 min / 3 heures

**Objectif**:
Organisation / Outils et tâches

### 1. Objectif de la journée

Cette deuxième journée a été consacrée à l'organisation du développement de Meadowbound. L'objectif était de définir une méthodologie adaptée à un projet individuel, de justifier les principaux choix techniques et de préparer le suivi des tâches à l'aide de GitHub.

Le travail a également porté sur l'identification des fonctionnalités prioritaires, la préparation d'une première planification et la mise en place du journal de bord pour suivre l'avancement du projet.

### 2. Déroulement de la journée

| Activité                       | Travail effectué                                                                                 | Durée   |
| ------------------------------ | ------------------------------------------------------------------------------------------------ | ------- |
| Méthodologie de projet         | Définition de l'approche Agile simplifiée et du développement par composants et vertical slices. | 25 min  |
| Environnement de développement | Description de l'environnement C#, MonoGame, Git et GitHub.                                      | 25 min  |
| Choix techniques               | Justification des technologies et réflexion sur le stockage des données.                         | 30 min  |
| Définition des fonctionnalités | Formalisation du MVP, des priorités et des critères de validation.                               | 35 min  |
| Backlog GitHub                 | Préparation de la répartition des fonctionnalités en issues distinctes.                          | 25 min  |
| Planification                  | Définition des premières étapes et des objectifs hebdomadaires.                                  | 20 min  |
| Journal de bord                | Définition de la structure de suivi quotidien.                                                   | 20 min  |
| Total                          |                                                                                                  | 180 min |

### 3. Travaux réalisés

Une méthodologie adaptée au développement individuel a été définie. Elle combine une organisation par composants, une approche Agile simplifiée et la réalisation de vertical slices. Cette organisation doit permettre de développer progressivement des ensembles de fonctionnalités cohérents, puis de vérifier leur fonctionnement dans le jeu.

L'environnement technique a été décrit autour de C# et MonoGame pour le développement, de Git pour le suivi des versions et de GitHub pour l'hébergement du code et la gestion des tâches.

Les principaux choix techniques ont été justifiés. C# permet de structurer le code, tandis que MonoGame offre la liberté nécessaire pour concevoir l'architecture du jeu. Le format JSON a été envisagé pour certaines données et les sauvegardes, sous réserve de confirmer son adéquation aux besoins définitifs.

Le périmètre du MVP a ensuite été détaillé. Les fonctionnalités indispensables ont été classées en priorité P0, tandis que les fonctionnalités pouvant être reportées ont été classées en P1. Une boucle de jeu complète a été retenue comme critère global de validation : se déplacer, préparer le sol, planter, attendre la croissance, récolter, sauvegarder et reprendre sa partie.

Enfin, la gestion des tâches a été préparée autour de GitHub Issues. Le principe retenu est de créer une issue par tâche identifiable, avec un objectif précis et un critère de validation. Une première planification hebdomadaire a également été définie, avec l'objectif de disposer d'une version fonctionnelle à la fin de chaque cycle.

### 4. Résultats obtenus

- Définition de la méthodologie de développement.
- Description de l'environnement technique.
- Justification des principaux choix technologiques.
- Formalisation du MVP et de ses critères de validation.
- Préparation de l'organisation du backlog GitHub.
- Première ébauche de la planification.
- Définition de la structure du journal de bord.

### 5. Difficultés et points de vigilance

Le principal enjeu consiste à conserver une architecture suffisamment claire sans consacrer trop de temps à la conception avant d'obtenir un résultat concret. L'approche par composants et les vertical slices devront donc être appliquées de manière pragmatique.

La planification reste également dépendante de la difficulté réelle des premières fonctionnalités. Il faudra éviter de considérer les estimations initiales comme des échéances définitives.

Enfin, le backlog devra être maintenu à jour : les tâches terminées devront être validées, tandis que les difficultés rencontrées pourront conduire à créer de nouvelles issues ou à revoir les priorités.

### 6. Bilan de la journée

Cette deuxième journée a permis de préciser l'organisation technique et méthodologique du projet. Les principales fonctionnalités sont désormais identifiées, les outils de développement sont définis et une première structure de suivi du travail est prévue.

La prochaine étape consistera à passer de la préparation à la réalisation concrète. Il faudra notamment vérifier l'environnement MonoGame, initialiser ou finaliser le dépôt GitHub, créer les issues prioritaires et commencer le développement d'une première version affichant une carte.

### 7. Prochaines étapes

- Vérifier la configuration de l'environnement C# et MonoGame.
- Initialiser ou finaliser le dépôt GitHub.
- Créer les issues correspondant aux premières tâches.
- Définir la structure initiale du code.
- Réaliser une première carte de test.
- Vérifier l'affichage et le fonctionnement général du projet.
- Mettre à jour le backlog et le journal de bord après chaque session.
