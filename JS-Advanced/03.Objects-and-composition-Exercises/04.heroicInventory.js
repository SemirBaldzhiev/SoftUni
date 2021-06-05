function solve(arr){
    let heroes = [];

    for (let i = 0; i < arr.length; i++) {
        let [heroName, level, heroItems] = arr[i].split(' / ');

        if (heroItems !== undefined) {
        }
        
        let items = heroItems !== undefined ? heroItems.split(', ') : [];
        let hero = {};

        hero.name = heroName;
        hero.level = Number(level);
        hero.items = items;

        heroes.push(hero);
    }

    return JSON.stringify(heroes);
}
