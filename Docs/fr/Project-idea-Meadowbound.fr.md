# Cahier des charges — Jeu de farming en monde ouvert 2.5D

Projet C# / MonoGame · Document de cadrage · Nom du jeu : Meadowbound · Version 1.0

L’objectif est de transformer ta carte mentale en un document de projet professionnel, structuré autour de trois axes : les besoins, la solution proposée et la documentation.

Le document doit pouvoir servir à la fois de base de développement, de support de présentation et de référence pour suivre l'avancement du projet. Il distingue clairement la vision finale du jeu, le périmètre réaliste de la première version (MVP) et les évolutions futures.

# 1. Nécessaire — Analyse du besoin

## 1.1. Situation initiale

Le projet consiste à développer un jeu de simulation agricole en monde ouvert, en C# avec le framework MonoGame. Le joueur incarne un fermier ou une fermière et évolue dans un environnement représenté en 2.5D, avec une caméra oblique donnant une impression de profondeur à partir d'éléments graphiques en deux dimensions.

Le jeu doit proposer une expérience calme et immersive, dans laquelle le joueur peut cultiver des plantes, gérer une ferme, explorer son environnement et progresser au fil du temps.

La vision complète comprend également l'élevage, l'artisanat, la construction, le commerce, les relations avec les personnages non joueurs (PNJ), les saisons et les événements dynamiques. Cependant, développer tous ces systèmes dès le départ représenterait une charge importante.

Il est donc nécessaire de définir une première version limitée, mais fonctionnelle, qui permettra de valider les choix techniques et les principales mécaniques avant d'étendre le jeu.

## 1.2. Besoin

Le projet nécessite la création d'une base technique permettant de :

- Afficher un environnement 2D avec une perspective oblique cohérente.
- Déplacer le personnage dans le monde et gérer ses collisions.
- Interagir avec les éléments du décor.
- Cultiver, faire pousser et récolter des plantes.
- Gérer les objets, les ressources et l'inventaire.
- Sauvegarder et restaurer la progression.
- Structurer le code pour ajouter ultérieurement de nouveaux systèmes sans devoir réécrire l'ensemble du jeu.

Le besoin principal est donc de concevoir un prototype jouable, stable et évolutif, plutôt que de chercher à produire immédiatement un monde ouvert complet.

## 1.3. Objectifs du projet

Objectif fonctionnel

Permettre au joueur de se déplacer, d'interagir avec le monde, de cultiver et de récolter des plantes.

Objectif technique

Mettre en place une architecture modulaire en C# avec MonoGame, facilitant les tests, la maintenance et les extensions.

Objectif artistique

Créer une ambiance chaleureuse, une lecture claire des éléments et une profondeur visuelle convaincante en 2.5D.

Objectif d'évolution

Préparer l'ajout progressif des animaux, de la construction, des PNJ, des saisons et de l'exploration.

## 1.4. Périmètre du projet

Il faut distinguer trois niveaux afin d'éviter que le projet ne devienne trop ambitieux dès ses premières étapes.

| Niveau                         | Contenu                                                                                                                           |
| ------------------------------ | --------------------------------------------------------------------------------------------------------------------------------- |
| MVP — version minimale jouable | Une petite carte, un personnage mobile, une caméra, des collisions, quelques parcelles agricoles, des cultures et une sauvegarde. |
| Version 1 enrichie             | Inventaire complet, plusieurs cultures, gestion du temps, économie simple, interface améliorée et premiers bâtiments.             |
| Vision à long terme            | Monde ouvert étendu, animaux, artisanat, construction avancée, PNJ, quêtes, saisons, météo et événements.                         |

Hors périmètre du MVP : multijoueur, monde immense, intelligence artificielle complexe des PNJ, génération procédurale avancée et automatisation complète de la ferme. Ces éléments pourront être étudiés ultérieurement.

## 1.5. Éléments nécessaires à la base du projet

Voici la liste des fondations à prévoir avant de développer les systèmes avancés.

- Environnement de développement C# et projet MonoGame fonctionnels.
- Dépôt Git et organisation des versions du code.
- Fenêtre de jeu, boucle principale et gestion des entrées.
- Chargement des textures, polices et ressources.
- Carte composée de tuiles et représentation des obstacles.
- Déplacement du personnage et détection des collisions.
- Caméra suivant le joueur et limites de la carte.
- Système de profondeur pour afficher correctement les sprites.
- Système d'interaction avec les objets du monde.
- Modèle de données pour les cultures et leur croissance.
- Inventaire simple et gestion des ressources.
- Sauvegarde et chargement des données essentielles.
- Interface de jeu minimale.
- Gestion des erreurs et tests des systèmes critiques.
- Documentation technique et consignes d'installation.

## 1.6. Fonctionnalités attendues dans le MVP

Légende : P0 = indispensable ; P1 = important, mais peut être reporté si nécessaire.

| Fonctionnalité              | Priorité | Critère de validation                                             |
| --------------------------- | -------- | ----------------------------------------------------------------- |
| Affichage de la carte       | P0       | La carte est chargée et visible sans erreur.                      |
| Déplacement                 | P0       | Le personnage se déplace dans les quatre directions prévues.      |
| Caméra 2.5D                 | P0       | La caméra suit le joueur sans sortir des limites.                 |
| Collisions                  | P0       | Les obstacles empêchent le passage du personnage.                 |
| Tri de profondeur           | P0       | Le joueur peut passer visuellement devant et derrière les objets. |
| Préparation du sol          | P0       | Une parcelle peut changer d'état.                                 |
| Plantation                  | P0       | Une graine peut être plantée sur une parcelle valide.             |
| Croissance                  | P0       | Une plante évolue entre plusieurs stades selon le temps de jeu.   |
| Récolte                     | P0       | Une plante arrivée à maturité produit une ressource.              |
| Inventaire                  | P0       | Les ressources récoltées sont stockées et comptabilisées.         |
| Sauvegarde                  | P0       | La progression essentielle est restaurée après redémarrage.       |
| Interface                   | P0       | Le joueur comprend les commandes et l'état de son inventaire.     |
| Sons et animations avancées | P1       | Peuvent être intégrés après validation du gameplay principal.     |
| Commerce et PNJ             | P1       | Préparés pour une version ultérieure.                             |

Le MVP sera considéré comme validé lorsque le joueur pourra effectuer une boucle de jeu complète : se déplacer → préparer une parcelle → planter → attendre → récolter → sauvegarder → reprendre sa partie.

# 2. Solution — Conception et réalisation

## 2.1. Solution générale proposée

La solution consiste à développer le jeu sous la forme d'une application MonoGame organisée en modules indépendants. Chaque module sera responsable d'un domaine précis du jeu : affichage, déplacement, carte, agriculture, inventaire ou sauvegarde.

L'objectif est de limiter les dépendances entre les systèmes. Par exemple, le système agricole ne doit pas dépendre directement du code de rendu graphique : il doit gérer les états des cultures, tandis que le rendu se charge de les afficher.

Le fonctionnement général sera organisé ainsi :

Entrées du joueur

Clavier · Souris · Commandes de jeu

Logique du jeu — C#

Joueur · Interactions · Agriculture · Inventaire · Temps

État du monde

Carte · Objets · Cultures · Collisions · Progression

Rendu MonoGame

Caméra · Sprites · Profondeur · Interface · Audio

Les sauvegardes et les ressources persistantes communiquent avec les systèmes concernés.

## 2.2. Écrans à prévoir

La conception des écrans doit être faite avant leur implémentation. Des maquettes papier suffisent au départ : elles permettent de définir la disposition des éléments sans perdre du temps sur les détails graphiques.

[Comprar Everholm - PC (Steam) - Latin America](https://images.openai.com/static-rsc-4/TpuTCJqqpQy-FFjnthrX4IzCNWHmNEN1-w11lHCl8Q76Zsvy5HXODeEEgnBVJ8DvFYDuGEvWjSiMUb9AIfyjoXX6Pj5wJw2yKVelNtTvz8wmydMK-n0-GVrNV4SJsn8lzTQ0jTdKeeZfM_tWtn2Tgvh9y_KvwTlqTDYsAQafuUY?purpose=inline)

Écran 1 — Jeu principal

Carte, personnage, parcelles, barre d'outils, inventaire rapide, heure et énergie.

MVP : indispensable.

[50+ Cozy Games like Stardew Valley (in 2026)](https://images.openai.com/static-rsc-4/Q2Yz0Z3PoN9Z3iqkVsljjdqhMVsWwnR6RCFMV6CVwbHiLfOWBV0O2gKq-NrRoe_-TZ8x9ORRpEhwqiHXxnEKyfjw_cTXoCpJLryBaJsz8zjDtKVVYcvtSYuS-p1_DISbsPi3enW1e9LwYdVykfb1iwvStB3zCRnEmZy2XJbWNSw?purpose=inline)

Écran 2 — Inventaire

Liste des ressources, quantité de chaque objet et sélection des outils.

MVP : version simple.

[Stardew Valley Menu Redesign / UI Design — Cat Kydd](https://images.openai.com/static-rsc-4/GamztdySHFHZPeEFj93v-Ay8kYK05ZFenN48zlUIVVvrQsNvu7O_usulUAncK4lfXgr5KSg1AMzcogSDLd84EMI5-isfZfs5bC9NXdvyykgklq69PothrdyIONuNe3ohgkPW_DbKg_5jzEOytA43g4BifP7U_9_pV6Zq_KKiJFw?purpose=inline)

Écran 3 — Pause et options

Reprendre la partie, sauvegarder, régler le son et quitter le jeu.

MVP : commandes essentielles.

[Farm:Veg Options,Soil Types,Growth Stages. Game Design. :: Behance](https://images.openai.com/static-rsc-4/wy44cdddfXf-S1TVQJv6RTXK3gv6ZQGHdsWUjTeOrnpSlGfuXRCjdCthk6xnFtHtOq5EMCRKuum0tlVE97XxF-82jbNEwuRc-sP9AKt3u-iHOPvIb_cpylbbKUFkkIhTWiXxBnxoQ4X9qRf947JPJ2hBoArDNl-RjH_tRN7xeDU?purpose=inline)

Écran 4 — Interaction agricole

Sélection de l'outil, préparation du sol, plantation, arrosage et récolte.

MVP : intégré à l'écran principal.

### Maquettes papier à réaliser

Pour chaque écran, dessiner les zones principales, indiquer les actions disponibles et noter les informations visibles. Il faut également préciser les commandes clavier et souris, les états possibles des boutons et les transitions entre les écrans.

Les maquettes ne doivent pas nécessairement être belles : elles doivent être suffisamment claires pour servir de référence pendant le développement.

## 2.3. Choix technologiques et techniques

| Élément       | Solution envisagée                                  | Justification                                                      |
| ------------- | --------------------------------------------------- | ------------------------------------------------------------------ |
| Langage       | C#                                                  | Langage principal pour la logique, les objets et les systèmes.     |
| Framework     | MonoGame                                            | Gestion de la fenêtre, du rendu, des entrées et de l'audio.        |
| Environnement | Visual Studio ou Rider                              | Écriture, compilation et débogage du code.                         |
| Versionnement | Git                                                 | Historique, branches et retour à une version stable.               |
| Graphismes    | Sprites 2D et tuiles                                | Adaptés à une perspective oblique simulée.                         |
| Carte         | Grille de tuiles                                    | Facilite le placement des objets et des parcelles.                 |
| Données       | JSON pour les configurations et sauvegardes simples | Format lisible, adapté aux données structurées du jeu.             |
| Audio         | Système audio de MonoGame                           | Lecture des effets sonores et des musiques.                        |
| Tests         | Tests unitaires avec un framework .NET adapté       | Vérification de la croissance, de l'inventaire et des sauvegardes. |
| Documentation | Markdown ou document bureautique                    | Traçabilité des décisions et présentation du projet.               |

Les versions exactes de .NET, MonoGame et des outils devront être fixées au début du projet, puis consignées dans la documentation d'installation.

### Organisation initiale des fichiers

```
Meadowbound/
├── Meadowbound.sln
├── src/
│   └── Meadowbound/
│       ├── Game1.cs
│       ├── Core/
│       ├── Entities/
│       │   └── Player.cs
│       ├── World/
│       │   ├── MapManager.cs
│       │   └── Tile.cs
│       ├── Graphics/
│       │   ├── Camera2D.cs
│       │   └── SpriteRenderer.cs
│       ├── Systems/
│       │   ├── CollisionManager.cs
│       │   ├── FarmingSystem.cs
│       │   ├── Inventory.cs
│       │   └── SaveManager.cs
│       ├── UI/
│       └── Content/
├── tests/
├── docs/
└── README.md
```

Cette arborescence est une base de départ. Les dossiers pourront être subdivisés lorsque le nombre de classes augmentera. Il est préférable d'éviter de créer trop de couches abstraites avant d'avoir identifié les besoins réels.

## 2.4. Points techniques à risque

Les risques doivent être identifiés tôt, car certains choix peuvent entraîner des corrections importantes s'ils sont faits trop tard.

| Risque                       | Conséquence possible                                       | Mesure préventive                                                                                          |
| ---------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------- |
| Perspective 2.5D mal définie | Décalages visuels et déplacements peu naturels             | Fixer la convention de coordonnées et la taille des tuiles dès le prototype.                               |
| Tri de profondeur incorrect  | Le personnage passe visuellement devant les mauvais objets | Trier selon une coordonnée de référence au sol, avec une gestion spécifique des grands sprites.            |
| Collisions complexes         | Blocages ou déplacements imprécis                          | Séparer la boîte de collision du dessin du sprite.                                                         |
| Monde trop grand             | Temps de chargement et consommation mémoire élevés         | Commencer avec une petite carte et prévoir le chargement par zones si nécessaire.                          |
| Architecture trop couplée    | Chaque nouvelle fonctionnalité provoque des régressions    | Séparer les données, les règles de jeu et le rendu.                                                        |
| Sauvegardes fragiles         | Perte ou corruption de progression                         | Tester le chargement, gérer les versions de données et éviter d'écraser directement une sauvegarde valide. |
| Graphismes non homogènes     | Rupture de perspective ou de style                         | Définir un guide artistique et des dimensions cohérentes.                                                  |
| Périmètre excessif           | Projet inachevé                                            | Geler le périmètre du MVP avant d'ajouter les fonctionnalités avancées.                                    |

Risque prioritaire : la perspective et le tri de profondeur. Il est recommandé de créer rapidement une scène de test contenant le personnage, un arbre, une clôture et un bâtiment. Le rendu et les collisions doivent être validés avant la production d'une grande quantité de contenu graphique.

## 2.5. Gestion du projet : rôles et droits

Même si le projet est réalisé par une seule personne, la séparation des rôles permet de clarifier les responsabilités.

| Rôle                        | Responsabilités                                       | Droits recommandés                                 |
| --------------------------- | ----------------------------------------------------- | -------------------------------------------------- |
| Chef de projet              | Priorités, périmètre, planning et validation          | Valide les changements de périmètre.               |
| Développeur gameplay        | Déplacements, agriculture, inventaire et interactions | Modifie le code des systèmes concernés.            |
| Développeur moteur et rendu | Caméra, collisions, profondeur et performances        | Modifie les composants techniques concernés.       |
| Artiste                     | Sprites, animations, décors et interface              | Gère les ressources graphiques.                    |
| Testeur et documentaliste   | Tests, anomalies, procédures et sources               | Signale les défauts et actualise la documentation. |

Dans une petite équipe, une même personne peut cumuler plusieurs rôles.

Pour le versionnement, les modifications doivent être associées à des commits explicites. Une branche principale doit rester compilable, et les changements importants doivent être testés avant leur intégration. Les droits de modification du dépôt dépendent de l'organisation de l'équipe et de l'hébergement utilisé.

## 2.6. Première étape concrète

La première étape consiste à créer un prototype technique minimal, et non à commencer directement le développement de toutes les mécaniques agricoles.

Livrables attendus :

1. Un projet MonoGame qui compile et démarre.
2. Une fenêtre affichant une carte de test.
3. Un personnage qui se déplace.
4. Une caméra qui suit le personnage.
5. Des obstacles avec des collisions.
6. Un arbre ou un bâtiment permettant de vérifier le tri de profondeur.
7. Un dépôt Git contenant le code source et les instructions de lancement.

Critère de réussite : le prototype doit pouvoir être lancé sur l'environnement de développement choisi, sans erreur bloquante, et démontrer que le rendu 2.5D et les déplacements sont techniquement viables.

# 3. Plan de développement — Liste des étapes

Le développement sera réalisé de manière progressive. Chaque étape doit aboutir à un résultat vérifiable avant de passer à la suivante. Les durées ci-dessous sont indicatives pour un développeur seul et devront être ajustées selon son expérience.

| Étape | Travail à réaliser                                                                      | Livrable attendu                |
| ----- | --------------------------------------------------------------------------------------- | ------------------------------- |
| 1     | Définir les besoins, le périmètre du MVP et les critères de réussite.                   | Cahier des charges validé.      |
| 2     | Créer le dépôt Git, installer les outils et configurer MonoGame.                        | Projet compilable.              |
| 3     | Mettre en place la boucle de jeu, les entrées et la gestion du temps de mise à jour.    | Fenêtre interactive.            |
| 4     | Définir la grille, les tuiles et le format des cartes.                                  | Carte de test affichée.         |
| 5     | Créer le joueur, ses animations de base et ses déplacements.                            | Personnage contrôlable.         |
| 6     | Développer la caméra, le zoom éventuel et les limites de déplacement.                   | Caméra fonctionnelle.           |
| 7     | Implémenter les collisions et le tri de profondeur.                                     | Scène 2.5D cohérente.           |
| 8     | Ajouter les interactions avec les objets et les outils.                                 | Interactions fonctionnelles.    |
| 9     | Développer la préparation du sol, les semis et la croissance.                           | Première boucle agricole.       |
| 10    | Ajouter l'arrosage, les stades de croissance et la récolte.                             | Cultures jouables.              |
| 11    | Créer l'inventaire et la barre d'outils rapides.                                        | Gestion des ressources.         |
| 12    | Développer les sauvegardes et le chargement.                                            | Progression persistante.        |
| 13    | Ajouter l'interface, les menus et les retours visuels.                                  | Interface MVP.                  |
| 14    | Réaliser les tests fonctionnels et corriger les anomalies.                              | Prototype stabilisé.            |
| 15    | Ajouter les sons, les animations et les améliorations graphiques prioritaires.          | Version jouable enrichie.       |
| 16    | Introduire le temps du jeu, le cycle jour/nuit et les premières données de progression. | Systèmes temporels.             |
| 17    | Développer les animaux, l'artisanat et le commerce.                                     | Extension gameplay.             |
| 18    | Ajouter les PNJ, les quêtes et les événements.                                          | Systèmes sociaux.               |
| 19    | Agrandir le monde et introduire de nouvelles zones.                                     | Exploration étendue.            |
| 20    | Optimiser le rendu, la mémoire et les temps de chargement.                              | Version optimisée.              |
| 21    | Finaliser les tests, les sources, les procédures et le guide utilisateur.               | Version documentée et livrable. |

## Organisation des jalons

J1

Prototype technique

Carte, personnage, caméra, collisions et profondeur.

J2

Boucle agricole

Préparation du sol, plantation, croissance, récolte et inventaire.

J3

MVP complet

Interface, sauvegarde, chargement et tests de la boucle de jeu.

J4

Extension du jeu

Nouveaux systèmes, zones, contenu et améliorations artistiques.

# 4. Documentation — Présentation professionnelle

## 4.1. Structure du dossier documentaire

Pour que le projet soit compréhensible par un enseignant, un évaluateur, un collaborateur ou un futur développeur, il faut produire une documentation concise, cohérente et vérifiable.

| Document                 | Contenu                                                                      |
| ------------------------ | ---------------------------------------------------------------------------- |
| 01 — Présentation        | Concept, contexte, objectifs et public visé.                                 |
| 02 — Cahier des charges  | Besoins, périmètre, fonctionnalités et critères de validation.               |
| 03 — Conception          | Architecture, diagrammes, écrans et maquettes.                               |
| 04 — Choix techniques    | C#, MonoGame, outils, formats de données et justifications.                  |
| 05 — Planification       | Étapes, priorités, jalons et suivi des tâches.                               |
| 06 — Réalisation         | Explication des systèmes développés et décisions prises.                     |
| 07 — Tests               | Cas de test, résultats, anomalies et corrections.                            |
| 08 — Sources             | Bibliographie, documentation officielle, tutoriels et ressources graphiques. |
| 09 — Utilisation de l'IA | Outils utilisés, objectifs, contribution et vérification des résultats.      |
| 10 — Bilan               | Résultats, limites, difficultés et améliorations futures.                    |

## 4.2. Règles de mise en forme

Le document final doit respecter les principes suivants :

- Employer une hiérarchie de titres constante et une table des matières.
- Rédiger avec des phrases courtes, précises et compréhensibles.
- Définir les termes techniques lors de leur première utilisation.
- Ajouter des captures d'écran et des schémas uniquement lorsqu'ils facilitent la compréhension.
- Numéroter les figures et les tableaux, et les mentionner dans le texte.
- Séparer les fonctionnalités réalisées, prévues et envisagées.
- Corriger l'orthographe et uniformiser le vocabulaire.
- Conserver un historique des décisions techniques importantes.

La documentation doit expliquer les choix, et non simplement énumérer les fonctionnalités.

## 4.3. Sources et références

Les sources doivent permettre au lecteur de vérifier les informations utilisées. Il faut distinguer la documentation technique, les références de conception et les ressources intégrées au jeu.

| Type de source                                | Utilisation                                                                                     |
| --------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| Documentation officielle MonoGame             | Comprendre l'initialisation, le rendu, les entrées et le chargement des ressources.             |
| Documentation Microsoft Learn pour C# et .NET | Vérifier les fonctionnalités du langage et les API utilisées.                                   |
| Documentation Git                             | Décrire la gestion du code source et les procédures de collaboration.                           |
| Tutoriels techniques                          | Comprendre une méthode, en indiquant l'auteur et le lien.                                       |
| Ressources artistiques                        | Identifier les auteurs, les licences et les conditions de réutilisation des images et des sons. |
| Expérimentations personnelles                 | Documenter les prototypes, les mesures et les résultats obtenus.                                |

Références de départ :

- [Documentation officielle MonoGame](https://docs.monogame.net/?utm_source=chatgpt.com)
- [Documentation C# — Microsoft Learn](https://learn.microsoft.com/fr-fr/dotnet/csharp/?utm_source=chatgpt.com)
- [Documentation .NET — Microsoft Learn](https://learn.microsoft.com/fr-fr/dotnet/?utm_source=chatgpt.com)
- [Documentation officielle Git](https://git-scm.com/doc?utm_source=chatgpt.com)

Il faut consulter les pages réellement utilisées et indiquer, selon le format demandé, le titre, l'auteur ou l'organisme, l'URL, la date de consultation et la partie du projet concernée.

## 4.4. Texte personnel et originalité

Le document doit refléter le travail réellement effectué.

Pour chaque choix technique important, il est conseillé d'expliquer :

1. Le problème rencontré ou le besoin identifié.
2. Les solutions envisagées.
3. La solution retenue.
4. Les raisons de ce choix.
5. Le résultat observé après mise en œuvre.

Les sources externes doivent être reformulées avec compréhension et citées. Les extraits de code provenant de tiers doivent être identifiés lorsqu'ils sont repris, dans le respect de leurs licences. La reformulation ne remplace pas une citation lorsqu'une idée ou une information provient d'une source.

Les expérimentations personnelles, les tests et les décisions motivées constituent la meilleure preuve de compréhension du projet.

## 4.5. Utilisation de l'intelligence artificielle

L'utilisation de l'IA doit être transparente, proportionnée et documentée. Elle peut aider à concevoir l'architecture, comprendre une erreur, comparer des solutions ou améliorer la lisibilité de la documentation. Elle ne remplace ni les tests ni la compréhension du code.

### Quantité d'utilisation

Il n'est pas nécessaire de fixer un pourcentage arbitraire de contenu généré par l'IA. Il est plus pertinent de consigner son utilisation réelle, par exemple dans un tableau de suivi.

| Date         | Outil        | Objectif                   | Résultat                     | Vérification                                  |
| ------------ | ------------ | -------------------------- | ---------------------------- | --------------------------------------------- |
| À renseigner | Assistant IA | Étudier l'architecture     | Proposition de structure     | Comparaison avec les besoins du projet        |
| À renseigner | Assistant IA | Comprendre une erreur C#   | Hypothèses de correction     | Compilation et tests                          |
| À renseigner | Assistant IA | Améliorer la documentation | Proposition de reformulation | Relecture personnelle et contrôle des sources |

Ce tableau est un modèle : il devra être rempli à partir des utilisations réellement effectuées.

### À quelles fins utiliser l'IA ?

- Conception : proposer des architectures et identifier les dépendances.
- Apprentissage : expliquer des concepts C#, MonoGame ou de rendu 2.5D.
- Débogage : analyser les messages d'erreur et proposer des pistes.
- Tests : suggérer des cas limites et des scénarios de validation.
- Documentation : améliorer la structure et la clarté des textes.
- Planification : décomposer les fonctionnalités en tâches réalisables.

### Limites et précautions

Les réponses générées peuvent contenir des erreurs, des API inexistantes ou des solutions mal adaptées au projet. Tout code proposé doit être compris, testé et adapté avant son intégration. Les sources, licences et affirmations techniques doivent être vérifiées indépendamment.

Si le projet est réalisé dans un cadre scolaire ou académique, les règles de l'établissement concernant l'IA prévalent : il faut notamment vérifier les obligations de déclaration, les restrictions et les modalités de citation.

# 5. Critères de réussite du projet

Le projet sera évalué à partir de résultats observables plutôt que du seul nombre de fonctionnalités développées.

- Fonctionnel : la boucle agricole du MVP est jouable de bout en bout.
- Technique : le projet compile et les systèmes essentiels fonctionnent de manière fiable.
- Graphique : la caméra, les collisions et le tri de profondeur sont cohérents.
- Persistance : la progression est conservée après sauvegarde et chargement.
- Architecture : les principales responsabilités sont séparées et les extensions restent réalisables.
- Qualité : les anomalies bloquantes sont corrigées et les cas critiques sont testés.
- Documentation : les choix, les sources, les tests et l'utilisation de l'IA sont explicités.
- Respect du périmètre : les fonctionnalités supplémentaires ne compromettent pas l'achèvement du MVP.

## 6. Prochaine action recommandée

Avant de commencer à coder, il reste à préciser le contexte du projet pour adapter le planning, les livrables et le niveau de détail de la documentation.

## Personnaliser le dossier de projet

Ces informations permettront d'adapter la version définitive du cahier des charges.

1\. Dans quel cadre réalises-tu ce projet ?

Projet personnel

Projet scolaire ou de formation

Projet professionnel

2\. Qui développe le jeu ?

Moi seul(e)

Petite équipe de 2 à 4 personnes

Équipe plus importante

3\. Quel est ton niveau en C# et MonoGame ?

Débutant

Intermédiaire

Avancé

4\. Quel délai envisages-tu ?

Moins de 3 mois

3 à 6 mois

6 à 12 mois

Plus de 12 mois

5\. Quel livrable veux-tu préparer en priorité ?

Cahier des charges professionnel complet

Architecture technique et plan de code C#

Planning détaillé avec tâches et estimations

Dossier scolaire avec méthodologie et bibliographie

Adapter le dossier

Le principe directeur reste le même : construire d'abord un petit jeu agricole entièrement fonctionnel, puis développer progressivement le monde ouvert et ses systèmes avancés.