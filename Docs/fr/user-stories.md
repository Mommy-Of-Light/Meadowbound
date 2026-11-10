# User stories pour les taches

## 1. Initialiser le projet et son architecture — [Issue #1](https://github.com/Mommy-Of-Light/Meadowbound/issues/1)

Objectif de l'Epic : Disposer d'une base technique fonctionnelle, organisée et évolutive pour développer Meadowbound.

### User Stories

US-01 — Créer et configurer le projet MonoGame en C# ([#9](https://github.com/Mommy-Of-Light/Meadowbound/issues/9))

En tant que développeur, je veux créer et configurer un projet MonoGame en C#, afin de disposer d'un environnement de développement fonctionnel pour Meadowbound.

Critères d'acceptation :

- Le projet MonoGame est créé avec la bonne version de .NET.
- Les dépendances nécessaires sont installées.
- Le projet peut être ouvert et exécuté depuis l'environnement de développement.
- La configuration initiale est versionnée sur GitHub.

US-02 — Définir l'organisation des dossiers et namespaces ([#10](https://github.com/Mommy-Of-Light/Meadowbound/issues/10))

En tant que développeur, je veux organiser les dossiers et les namespaces du projet, afin de faciliter la navigation, la maintenance et l'évolution du code.

Critères d'acceptation :

- Les dossiers principaux sont créés.
- Les classes sont regroupées par responsabilité.
- Les namespaces respectent l'organisation définie.
- La structure est documentée.

US-03 — Définir les responsabilités des principaux composants ([#11](https://github.com/Mommy-Of-Light/Meadowbound/issues/11))

En tant que développeur, je veux définir les responsabilités des principaux composants du jeu, afin de séparer clairement les différentes fonctionnalités.

Critères d'acceptation :

- Les composants principaux sont identifiés.
- Chaque composant possède une responsabilité définie.
- Les interactions entre composants sont documentées.
- Les responsabilités ne se chevauchent pas inutilement.

US-04 — Configurer le chargement des ressources du jeu ([#12](https://github.com/Mommy-Of-Light/Meadowbound/issues/12))

En tant que développeur, je veux mettre en place un système de chargement des ressources, afin de pouvoir utiliser les textures, images et autres assets dans le jeu.

Critères d'acceptation :

- Un système de gestion des ressources est disponible.
- Les ressources peuvent être chargées au lancement du jeu.
- Les ressources chargées sont accessibles aux composants concernés.
- Les erreurs de chargement sont identifiables.

US-05 — Vérifier que le projet compile et démarre correctement ([#13](https://github.com/Mommy-Of-Light/Meadowbound/issues/13))

En tant que développeur, je veux vérifier que le projet compile et démarre correctement, afin de m'assurer que l'environnement de développement est opérationnel.

Critères d'acceptation :

- Le projet compile sans erreur.
- Le jeu démarre sans planter.
- La fenêtre du jeu s'affiche correctement.
- Le jeu peut être fermé normalement.

## 2. Afficher la carte et déplacer le joueur — [Issue #2](https://github.com/Mommy-Of-Light/Meadowbound/issues/2)

Objectif de l'Epic : Permettre au joueur d'explorer un environnement représenté par une carte en 2D.

### User Stories

US-06 — Définir le format initial de la carte ([#14](https://github.com/Mommy-Of-Light/Meadowbound/issues/14))

En tant que développeur, je veux définir un format de données pour représenter la carte, afin de pouvoir décrire et charger facilement l'environnement du jeu.

Critères d'acceptation :

- Un format de représentation de la carte est défini.
- Les dimensions de la carte peuvent être spécifiées.
- Les différents types de tuiles peuvent être identifiés.
- Le format permet de représenter une carte composée de plusieurs tuiles.

US-07 — Charger et afficher la carte ([#15](https://github.com/Mommy-Of-Light/Meadowbound/issues/15))

En tant que joueur, je veux voir la carte du jeu s'afficher, afin de pouvoir découvrir et explorer mon environnement.

Critères d'acceptation :

- La carte est chargée depuis les données définies.
- Les textures des tuiles sont correctement affichées.
- Les tuiles sont positionnées conformément aux données de la carte.
- L'ensemble de la carte est rendu correctement.

US-08 — Créer le personnage joueur ([#16](https://github.com/Mommy-Of-Light/Meadowbound/issues/16))

En tant que joueur, je veux disposer d'un personnage visible dans le jeu, afin de pouvoir incarner un personnage et explorer le monde.

Critères d'acceptation :

- Un personnage joueur est créé.
- Une texture ou un sprite lui est associé.
- Sa position initiale est définie.
- Le personnage est affiché sur la carte.

US-09 — Implémenter les déplacements dans les quatre directions ([#17](https://github.com/Mommy-Of-Light/Meadowbound/issues/17))

En tant que joueur, je veux pouvoir déplacer mon personnage dans les quatre directions, afin de me déplacer librement dans l'environnement.

Critères d'acceptation :

- Le personnage peut se déplacer vers le haut, le bas, la gauche et la droite.
- Les déplacements sont contrôlés par le clavier.
- La vitesse de déplacement est cohérente.
- Le personnage ne se déplace pas en l'absence d'une commande.
- Les déplacements diagonaux ne provoquent pas une vitesse supérieure aux déplacements normaux, si cette possibilité est activée.

US-10 — Créer une caméra qui suit le joueur ([#18](https://github.com/Mommy-Of-Light/Meadowbound/issues/18))

En tant que joueur, je veux que la caméra suive mon personnage lorsqu'il se déplace, afin de pouvoir explorer les différentes zones de la carte.

Critères d'acceptation :

- La caméra suit la position du joueur.
- Le joueur reste dans une zone visible de l'écran.
- Le déplacement de la caméra est fluide.
- La carte est correctement affichée pendant le déplacement.

US-11 — Limiter la caméra aux frontières de la carte ([#19](https://github.com/Mommy-Of-Light/Meadowbound/issues/19))

En tant que joueur, je veux que la caméra reste dans les limites de la carte, afin de ne pas voir des zones situées en dehors de l'environnement du jeu.

Critères d'acceptation :

- La caméra ne dépasse pas les limites horizontales de la carte.
- La caméra ne dépasse pas les limites verticales de la carte.
- Les limites sont respectées lorsque le joueur atteint les bords de la carte.
- Aucun espace vide non prévu n'apparaît à l'écran.

## 3. Gérer les collisions et la profondeur — [Issue #3](https://github.com/Mommy-Of-Light/Meadowbound/issues/3)

Objectif de l'Epic : Garantir des déplacements cohérents et un affichage réaliste des éléments de l'environnement.

### User Stories

US-12 — Définir les obstacles et leurs zones de collision ([#20](https://github.com/Mommy-Of-Light/Meadowbound/issues/20))

En tant que développeur, je veux définir les obstacles présents sur la carte et leurs zones de collision, afin de déterminer les endroits où le joueur ne peut pas se déplacer.

Critères d'acceptation :

- Les obstacles sont identifiés sur la carte.
- Chaque obstacle possède une zone de collision définie.
- Les zones de collision sont indépendantes de la taille visuelle du sprite lorsque nécessaire.
- Les zones de collision sont correctement positionnées.

US-13 — Empêcher le joueur de traverser les obstacles ([#21](https://github.com/Mommy-Of-Light/Meadowbound/issues/21))

En tant que joueur, je veux que mon personnage soit bloqué par les obstacles, afin de respecter les limites physiques de l'environnement.

Critères d'acceptation :

- Le joueur ne peut pas traverser les obstacles.
- Les collisions sont détectées dans les quatre directions.
- Le joueur peut se déplacer le long d'un obstacle.
- Les collisions ne provoquent pas de blocage involontaire.

US-14 — Définir la règle de tri de profondeur des objets ([#22](https://github.com/Mommy-Of-Light/Meadowbound/issues/22))

En tant que joueur, je veux que les objets soient affichés selon leur profondeur dans le monde, afin de bénéficier d'un rendu visuel cohérent.

Critères d'acceptation :

- Une règle de tri de profondeur est définie.
- Les objets sont affichés selon leur position dans le monde.
- Le système prend en compte la position du joueur.
- L'ordre d'affichage est recalculé lorsque cela est nécessaire.

US-15 — Vérifier les déplacements devant et derrière les objets ([#23](https://github.com/Mommy-Of-Light/Meadowbound/issues/23))

En tant que joueur, je veux pouvoir passer devant et derrière certains objets, afin de bénéficier d'une représentation spatiale cohérente de l'environnement.

Critères d'acceptation :

- Le joueur peut passer devant les objets concernés.
- Le joueur peut passer derrière les objets concernés.
- L'ordre d'affichage change en fonction de la position du joueur.
- Les sprites ne présentent pas de superposition incohérente.

## 4. Implémenter la boucle d'agriculture — [Issue #4](https://github.com/Mommy-Of-Light/Meadowbound/issues/4)

Objectif de l'Epic : Permettre au joueur de préparer le sol, planter des graines, faire pousser des plantes et récolter les cultures.

### User Stories

US-16 — Créer le système d'interaction avec les parcelles ([#24](https://github.com/Mommy-Of-Light/Meadowbound/issues/24))

En tant que joueur, je veux pouvoir interagir avec les parcelles de terrain, afin de réaliser les différentes actions agricoles.

Critères d'acceptation :

- Les parcelles interactives sont identifiées.
- Le joueur peut sélectionner ou cibler une parcelle.
- Les interactions sont déclenchées par une commande définie.
- Seules les parcelles accessibles peuvent être ciblées.

US-17 — Définir les états possibles d'une parcelle ([#25](https://github.com/Mommy-Of-Light/Meadowbound/issues/25))

En tant que développeur, je veux définir les différents états d'une parcelle, afin de gérer correctement son évolution au cours des activités agricoles.

Critères d'acceptation :

- Les états d'une parcelle sont définis (sol vierge, sol préparé, graine plantée, plante en croissance, plante mature).
- Chaque état est identifiable par le système.
- Les transitions entre les états sont définies.
- Les transitions impossibles sont interdites.

US-18 — Implémenter la préparation du sol ([#26](https://github.com/Mommy-Of-Light/Meadowbound/issues/26))

En tant que joueur, je veux pouvoir préparer une parcelle de terrain, afin de la rendre utilisable pour la plantation.

Critères d'acceptation :

- Le joueur peut préparer une parcelle valide.
- L'état de la parcelle change après préparation.
- L'apparence visuelle de la parcelle est mise à jour.
- Une parcelle déjà préparée ne peut pas être préparée inutilement.

US-19 — Permettre de planter une graine sur une parcelle valide ([#27](https://github.com/Mommy-Of-Light/Meadowbound/issues/27))

En tant que joueur, je veux pouvoir planter une graine sur une parcelle préparée, afin de commencer à cultiver une plante.

Critères d'acceptation :

- Le joueur peut sélectionner une graine disponible.
- La plantation est possible uniquement sur une parcelle valide.
- La quantité de graines dans l'inventaire est diminuée après plantation.
- L'état de la parcelle est mis à jour.
- Une représentation visuelle de la graine ou de la plante apparaît.

US-20 — Définir les données et les stades de croissance d'une plante ([#28](https://github.com/Mommy-Of-Light/Meadowbound/issues/28))

En tant que développeur, je veux définir les données et les différents stades de croissance des plantes, afin de pouvoir gérer plusieurs types de cultures.

Critères d'acceptation :

- Chaque plante possède des données définies.
- Les différents stades de croissance sont identifiés.
- Une durée de croissance est définie pour chaque stade.
- Les données permettent de distinguer les différents types de plantes.

US-21 — Faire progresser les plantes avec le temps de jeu ([#29](https://github.com/Mommy-Of-Light/Meadowbound/issues/29))

En tant que joueur, je veux que mes plantes grandissent avec le temps de jeu, afin de pouvoir suivre leur évolution jusqu'à leur maturité.

Critères d'acceptation :

- Les plantes évoluent automatiquement avec le temps.
- Chaque plante passe par les stades de croissance définis.
- La progression respecte les durées configurées.
- Une plante mature ne progresse plus vers un autre stade non défini.
- L'apparence de la plante évolue selon son stade de croissance.

US-22 — Permettre la récolte des plantes arrivées à maturité ([#30](https://github.com/Mommy-Of-Light/Meadowbound/issues/30))

En tant que joueur, je veux pouvoir récolter les plantes arrivées à maturité, afin de récupérer les ressources produites par mes cultures.

Critères d'acceptation :

- Une plante peut être récoltée uniquement lorsqu'elle est mature.
- La récolte ajoute les ressources correspondantes à l'inventaire.
- La plante disparaît ou la parcelle change d'état après récolte.
- Une même plante ne peut pas être récoltée plusieurs fois.

## 5. Créer l'inventaire et l'interface utilisateur — [Issue #5](https://github.com/Mommy-Of-Light/Meadowbound/issues/5)

Objectif de l'Epic : Permettre au joueur de consulter et de gérer les ressources collectées pendant sa partie.

### User Stories

US-23 — Définir la structure des objets et des ressources ([#31](https://github.com/Mommy-Of-Light/Meadowbound/issues/31))

En tant que développeur, je veux définir une structure commune pour les objets et les ressources, afin de pouvoir les identifier et les gérer facilement dans le jeu.

Critères d'acceptation :

- Chaque objet possède un identifiant unique.
- Chaque objet possède un nom.
- Les objets peuvent être associés à une représentation visuelle.
- Les ressources peuvent être distinguées selon leur type.
- La structure permet d'ajouter de nouveaux objets ultérieurement.

US-24 — Créer le système de stockage et de comptage des ressources ([#32](https://github.com/Mommy-Of-Light/Meadowbound/issues/32))

En tant que joueur, je veux que mes ressources soient stockées et comptabilisées, afin de connaître les quantités que je possède.

Critères d'acceptation :

- L'inventaire permet de stocker différents types de ressources.
- Chaque ressource possède une quantité.
- Les quantités peuvent être augmentées ou diminuées.
- Les quantités ne peuvent pas devenir négatives.
- Le système permet de retrouver une ressource à partir de son identifiant.

US-25 — Ajouter les ressources récoltées à l'inventaire ([#33](https://github.com/Mommy-Of-Light/Meadowbound/issues/33))

En tant que joueur, je veux que les ressources obtenues lors des récoltes soient automatiquement ajoutées à mon inventaire, afin de conserver les fruits de mon travail.

Critères d'acceptation :

- Les ressources sont ajoutées après une récolte réussie.
- La quantité ajoutée correspond au rendement de la récolte.
- Les ressources sont correctement identifiées.
- Les quantités déjà présentes sont mises à jour.

US-26 — Afficher les commandes essentielles ([#34](https://github.com/Mommy-Of-Light/Meadowbound/issues/34))

En tant que joueur, je veux pouvoir consulter les commandes essentielles du jeu, afin de comprendre comment interagir avec mon environnement.

Critères d'acceptation :

- Les commandes principales sont affichées à l'écran.
- Chaque commande est associée à son action.
- Les touches affichées correspondent aux contrôles réellement implémentés.
- Les indications restent lisibles pendant le jeu.

US-27 — Afficher le contenu et les quantités de l'inventaire ([#35](https://github.com/Mommy-Of-Light/Meadowbound/issues/35))

En tant que joueur, je veux consulter le contenu de mon inventaire et les quantités de chaque ressource, afin de connaître les objets dont je dispose.

Critères d'acceptation :

- L'inventaire peut être ouvert et fermé.
- Les ressources possédées sont affichées.
- Chaque ressource indique sa quantité.
- L'affichage est actualisé lorsque l'inventaire change.
- L'interface reste lisible et compréhensible.

## 6. Implémenter la sauvegarde et le chargement — [Issue #6](https://github.com/Mommy-Of-Light/Meadowbound/issues/6)

Objectif de l'Epic : Permettre au joueur de conserver sa progression et de reprendre une partie ultérieurement.

### User Stories

US-28 — Définir les données à conserver dans une sauvegarde ([#36](https://github.com/Mommy-Of-Light/Meadowbound/issues/36))

En tant que joueur, je veux que les informations importantes de ma partie soient identifiées pour la sauvegarde, afin de pouvoir retrouver ma progression ultérieurement.

Critères d'acceptation :

- La position du joueur est identifiée comme donnée à sauvegarder.
- L'état des parcelles et des plantes est pris en compte.
- Le contenu et les quantités de l'inventaire sont pris en compte.
- Les données nécessaires à la reprise d'une partie sont définies.

US-29 — Choisir et implémenter le format de sauvegarde ([#37](https://github.com/Mommy-Of-Light/Meadowbound/issues/37))

En tant que développeur, je veux choisir et implémenter un format de sauvegarde adapté, afin de pouvoir enregistrer et récupérer les données du jeu de manière fiable.

Critères d'acceptation :

- Un format de sauvegarde est choisi.
- Les données peuvent être converties dans ce format.
- Les données peuvent être relues depuis le fichier.
- Les erreurs de lecture et d'écriture sont gérées.

US-30 — Enregistrer l'état du joueur, du monde et de l'inventaire ([#38](https://github.com/Mommy-Of-Light/Meadowbound/issues/38))

En tant que joueur, je veux pouvoir enregistrer ma partie, afin de conserver mon état de progression actuel.

Critères d'acceptation :

- La position du joueur est enregistrée.
- L'état des parcelles et des plantes est enregistré.
- Le contenu de l'inventaire est enregistré.
- Les données sont écrites dans un fichier de sauvegarde.
- Une sauvegarde réussie ne perd aucune donnée prévue.

US-31 — Charger les données au lancement ou à la reprise d'une partie ([#39](https://github.com/Mommy-Of-Light/Meadowbound/issues/39))

En tant que joueur, je veux pouvoir charger une sauvegarde existante, afin de reprendre ma partie là où je l'avais laissée.

Critères d'acceptation :

- Le jeu détecte la présence d'une sauvegarde.
- Les données sont chargées correctement.
- La position du joueur est restaurée.
- L'état du monde et de l'inventaire est restauré.
- En l'absence de sauvegarde valide, une nouvelle partie peut être lancée.

US-32 — Tester la sauvegarde et le chargement après redémarrage ([#40](https://github.com/Mommy-Of-Light/Meadowbound/issues/40))

En tant que joueur, je veux retrouver ma progression après avoir fermé puis relancé le jeu, afin de ne pas perdre mes données.

Critères d'acceptation :

- Une partie peut être sauvegardée.
- Le jeu peut être fermé puis redémarré.
- Les données sauvegardées sont restaurées.
- Les informations du joueur, du monde et de l'inventaire correspondent à celles enregistrées.
- Aucun changement inattendu n'apparaît après le chargement.

## 7. Intégrer et valider le MVP — [Issue #7](https://github.com/Mommy-Of-Light/Meadowbound/issues/7)

Objectif de l'Epic : Assembler les fonctionnalités principales du jeu et vérifier que le MVP (Minimum Viable Product) est jouable et stable.

### User Stories

US-33 — Intégrer les composants dans une version jouable ([#41](https://github.com/Mommy-Of-Light/Meadowbound/issues/41))

En tant que joueur, je veux pouvoir utiliser une version intégrée du jeu, afin de profiter des différentes fonctionnalités dans une expérience cohérente.

Critères d'acceptation :

- Les différents composants du jeu sont intégrés.
- La carte et le personnage sont fonctionnels.
- Les déplacements et les collisions fonctionnent.
- Les systèmes d'agriculture et d'inventaire sont opérationnels.
- Les composants communiquent correctement entre eux.
- Le jeu peut être lancé et utilisé sans erreur bloquante.

US-34 — Tester la boucle complète de plantation et de récolte ([#42](https://github.com/Mommy-Of-Light/Meadowbound/issues/42))

En tant que joueur, je veux pouvoir effectuer toutes les étapes de l'agriculture, afin de vérifier que le cycle de culture fonctionne correctement.

Critères d'acceptation :

- Le joueur peut préparer une parcelle.
- Le joueur peut planter une graine.
- La plante évolue avec le temps.
- Le joueur peut récolter une plante mature.
- Les ressources récoltées sont ajoutées à l'inventaire.
- Le cycle peut être répété sur une nouvelle parcelle.

US-35 — Tester la persistance de la progression après redémarrage ([#43](https://github.com/Mommy-Of-Light/Meadowbound/issues/43))

En tant que joueur, je veux retrouver l'état de ma partie après un redémarrage, afin de pouvoir continuer ma progression sans recommencer.

Critères d'acceptation :

- Une partie contenant des cultures et des ressources peut être sauvegardée.
- Le jeu peut être fermé et relancé.
- Les données du joueur sont restaurées.
- Les parcelles et les cultures conservent leur état.
- L'inventaire conserve les mêmes ressources et quantités.

US-36 — Corriger les erreurs bloquantes détectées ([#44](https://github.com/Mommy-Of-Light/Meadowbound/issues/44))

En tant que joueur, je veux que les erreurs bloquantes soient corrigées, afin de pouvoir jouer sans rencontrer de problèmes empêchant la progression.

Critères d'acceptation :

- Les erreurs bloquantes identifiées sont répertoriées.
- Chaque erreur bloquante est corrigée.
- Les fonctionnalités concernées sont testées après correction.
- Aucune nouvelle erreur bloquante n'est introduite.
- Le jeu peut être lancé et utilisé normalement.

US-37 — Vérifier que les fonctionnalités déjà validées restent opérationnelles ([#45](https://github.com/Mommy-Of-Light/Meadowbound/issues/45))

En tant que joueur, je veux que les fonctionnalités précédemment développées continuent de fonctionner après les modifications, afin de bénéficier d'une expérience de jeu stable.

Critères d'acceptation :

- Les déplacements du joueur fonctionnent toujours.
- Les collisions et la caméra fonctionnent correctement.
- Le système d'agriculture reste opérationnel.
- L'inventaire fonctionne correctement.
- La sauvegarde et le chargement restent fonctionnels.
- Les tests de non-régression sont concluants.

# 8. Préparer les fonctionnalités post-MVP — [Issue #8](https://github.com/Mommy-Of-Light/Meadowbound/issues/8)

Objectif de l'Epic : Identifier et étudier les possibilités d'évolution du jeu après la livraison du MVP, afin de préparer les prochaines fonctionnalités.

### User Stories

US-38 — Étudier l'ajout de sons et d'animations avancées ([#46](https://github.com/Mommy-Of-Light/Meadowbound/issues/46))

En tant que joueur, je veux bénéficier d'effets sonores et d'animations plus avancées, afin de profiter d'une expérience de jeu plus immersive et agréable.

Critères d'acceptation :

- Les besoins en effets sonores sont identifiés.
- Les animations pouvant être ajoutées sont répertoriées.
- Les possibilités techniques offertes par MonoGame sont étudiées.
- L'impact sur les performances est évalué.
- Une proposition d'intégration est documentée.

US-39 — Étudier le système de commerce ([#47](https://github.com/Mommy-Of-Light/Meadowbound/issues/47))

En tant que joueur, je veux pouvoir envisager un système de commerce, afin de donner une utilité économique aux ressources que je récolte.

Critères d'acceptation :

- Les principes du système de commerce sont définis.
- Les ressources pouvant être vendues ou achetées sont identifiées.
- Un système de monnaie est envisagé.
- Les mécanismes de vente et d'achat sont étudiés.
- Une proposition de fonctionnement est documentée.

US-40 — Étudier les interactions avec les PNJ ([#48](https://github.com/Mommy-Of-Light/Meadowbound/issues/48))

En tant que joueur, je veux pouvoir interagir avec des personnages non-joueurs (PNJ), afin de rendre le monde plus vivant et de découvrir de nouvelles possibilités de gameplay.

Critères d'acceptation :

- Les différents types de PNJ pouvant être intégrés sont identifiés.
- Les interactions possibles sont répertoriées.
- Les possibilités de dialogue sont étudiées.
- Les éventuelles interactions avec le système de commerce sont identifiées.
- Une proposition d'intégration est documentée.