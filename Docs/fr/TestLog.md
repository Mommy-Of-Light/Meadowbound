# Suivi de de tests

## 1. Tests fonctionnels indispensables

| ID  | Fonctionnalité            | Test à effectuer                                | Résultat attendu                                                          | Priorité |
| --- | ------------------------- | ----------------------------------------------- | ------------------------------------------------------------------------- | -------- |
| T01 | Démarrage                 | Lancer le jeu                                   | Le jeu démarre sans erreur                                                | Haute    |
| T02 | Chargement des assets     | Charger le fichier `assets.json`                | Les textures et polices sont correctement chargées                        | Haute    |
| T03 | Gestion des assets        | Demander une texture existante                  | La bonne texture est retournée                                            | Haute    |
| T04 | Chargement du monde       | Charger `world.json`                            | Les dimensions, le nom et la seed sont correctement lus                   | Haute    |
| T05 | Génération du monde       | Générer une nouvelle carte                      | Toutes les cases de la carte sont remplies                                | Haute    |
| T06 | Génération par seed       | Générer deux mondes avec la même seed           | Les deux mondes possèdent exactement la même disposition                  | Haute    |
| T07 | Génération par seed       | Générer deux mondes avec des seeds différentes  | Les dispositions peuvent être différentes                                 | Haute    |
| T08 | Presets de terrain        | Générer plusieurs parcelles                     | Les parcelles utilisent les presets Meadow, Dirt Clearing et Rocky Ground | Haute    |
| T09 | Rendu du monde            | Afficher la carte                               | Toutes les cases sont affichées avec leur texture correspondante          | Haute    |
| T10 | Déplacement               | Déplacer le joueur avec ZQSD ou WASD            | Le joueur se déplace dans la direction souhaitée                          | Haute    |
| T11 | Limites du monde          | Déplacer le joueur jusqu'aux extrémités         | Le joueur ne peut pas sortir des limites de la carte                      | Haute    |
| T12 | Caméra                    | Déplacer le joueur                              | La caméra suit correctement le joueur                                     | Haute    |
| T13 | Limites de caméra         | Atteindre les bords de la carte                 | La caméra ne montre pas d'espace en dehors du monde                       | Haute    |
| T14 | Animations                | Déplacer le joueur                              | L'animation de marche correspondant à la direction est jouée              | Haute    |
| T15 | Animations                | Arrêter le joueur                               | L'animation d'inactivité est jouée                                        | Haute    |
| T16 | Outils                    | Sélectionner un outil avec une touche attribuée | Le bon outil est équipé                                                   | Haute    |
| T17 | Utilisation des outils    | Appuyer sur la touche d'utilisation             | L'animation correspondante est jouée                                      | Haute    |
| T18 | Sauvegarde                | Fermer puis relancer le jeu                     | Le monde sauvegardé est correctement chargé                               | Haute    |
| T19 | Mise à jour de sauvegarde | Modifier la taille ou la seed du monde          | Une nouvelle génération est effectuée et la sauvegarde est remplacée      | Haute    |
| T20 | Mise à jour de sauvegarde | Modifier les textures ou les données des tuiles | Le changement est détecté et le monde est régénéré                        | Haute    |

## 2. Tests complémentaires

Ces tests permettent de vérifier les comportements particuliers et de prévenir certains problèmes.

| ID  | Fonctionnalité        | Test à effectuer                                   | Résultat attendu                                             | Priorité |
| --- | --------------------- | -------------------------------------------------- | ------------------------------------------------------------ | -------- |
| T21 | Chargement des assets | Référencer une texture inexistante                 | Une erreur explicite est signalée                            | Moyenne  |
| T22 | Chargement du monde   | Charger un JSON mal formaté                        | Le chargement échoue proprement                              | Moyenne  |
| T23 | Dimensions du monde   | Définir une largeur ou hauteur négative ou nulle   | La génération refuse les dimensions invalides                | Haute    |
| T24 | Génération du monde   | Générer une carte de dimensions non multiples de 8 | Les parcelles partielles sont correctement générées          | Moyenne  |
| T25 | Génération du monde   | Générer une très petite carte                      | La carte est générée sans erreur                             | Moyenne  |
| T26 | Génération du monde   | Vérifier les coordonnées des tuiles                | Aucune tuile ne se trouve en dehors de la carte              | Haute    |
| T27 | Génération du monde   | Vérifier les positions des tuiles                  | Aucune position ne contient plusieurs tuiles                 | Haute    |
| T28 | Déplacement           | Maintenir plusieurs touches directionnelles        | La direction appliquée correspond au comportement prévu      | Moyenne  |
| T29 | Déplacement           | Maintenir une touche contre un bord                | Le joueur reste bloqué à la limite sans tremblement anormal  | Moyenne  |
| T30 | Animations            | Changer rapidement de direction                    | L'animation et l'orientation restent cohérentes              | Moyenne  |
| T31 | Animations            | Terminer une animation d'outil                     | Le joueur revient à son animation d'inactivité ou de marche  | Moyenne  |
| T32 | Sauvegarde            | Supprimer le fichier de sauvegarde                 | Le monde est régénéré automatiquement                        | Haute    |
| T33 | Sauvegarde            | Supprimer le fichier de hash                       | Le système détecte la sauvegarde comme obsolète et la recrée | Moyenne  |
| T34 | Sauvegarde            | Modifier uniquement le formatage du JSON           | Le changement est détecté avec le système de hash actuel     | Faible   |
| T35 | Performance           | Générer un monde de grande taille                  | La génération s'effectue sans blocage excessif               | Moyenne  |
| T36 | Performance           | Afficher un monde de grande taille                 | Le jeu conserve une fluidité acceptable                      | Moyenne  |

## 3. Tests d'intégration

Ces tests sont particulièrement importants : ils vérifient que plusieurs systèmes fonctionnent correctement ensemble.

| ID  | Systèmes concernés                  | Test à effectuer                                | Résultat attendu                                              | Priorité |
| --- | ----------------------------------- | ----------------------------------------------- | ------------------------------------------------------------- | -------- |
| T37 | WorldLoader + WorldGenerator        | Charger une configuration puis générer le monde | Le monde généré correspond à la configuration                 | Haute    |
| T38 | WorldGenerator + AssetManager       | Générer une carte puis charger ses textures     | Toutes les tuiles utilisent les bons assets                   | Haute    |
| T39 | WorldGenerator + SaveSystem         | Générer et sauvegarder un monde                 | Le monde sauvegardé correspond au monde généré                | Haute    |
| T40 | SaveSystem + WorldLoader            | Modifier la configuration puis relancer le jeu  | La nouvelle configuration est prise en compte                 | Haute    |
| T41 | MovementSystem + CameraSystem       | Déplacer le joueur dans le monde                | La caméra suit le joueur sans sortir des limites              | Haute    |
| T42 | InputSystem + AnimationSystem       | Déplacer le joueur dans différentes directions  | Les animations correspondent aux entrées clavier              | Haute    |
| T43 | InputSystem + AnimationSystem       | Utiliser un outil pendant le jeu                | L'animation de l'outil sélectionné est jouée                  | Haute    |
| T44 | WorldRenderingSystem + CameraSystem | Parcourir différentes zones de la carte         | Les tuiles sont correctement affichées pendant le déplacement | Haute    |

## 4. Tableau de suivi des tests

| ID  | Statut   | Date du test | Commentaires / Anomalies |
| --- | -------- | ------------ | ------------------------ |
| T01 | À tester | —            | —                        |
| T02 | À tester | —            | —                        |
| T03 | À tester | —            | —                        |
| T04 | À tester | —            | —                        |
| T05 | À tester | —            | —                        |
| T06 | À tester | —            | —                        |
| T07 | À tester | —            | —                        |
| T08 | À tester | —            | —                        |
| T09 | À tester | —            | —                        |
| T10 | À tester | —            | —                        |
| T11 | À tester | —            | —                        |
| T12 | À tester | —            | —                        |
| T13 | À tester | —            | —                        |
| T14 | À tester | —            | —                        |
| T15 | À tester | —            | —                        |
| T16 | À tester | —            | —                        |
| T17 | À tester | —            | —                        |
| T18 | À tester | —            | —                        |
| T19 | À tester | —            | —                        |
| T20 | À tester | —            | —                        |

Statuts possibles : À tester, Réussi, Échoué, Bloqué, À corriger.