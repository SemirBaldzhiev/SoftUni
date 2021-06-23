class ChristmasDinner {
    constructor(budget){
        
        this.budget = Number(budget);
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    set budget(value){
        if (value < 0) {
            throw new Error('The budget cannot be a negative number');
        }

        this._budget = value;
    }
     get budget() {
         return this._budget;
     }


    shopping([product, price]){
        //let [product, price] = productArr;
        price = Number(price)
        if (price > this._budget) {
            throw new Error('Not enough money to buy this product');
        }
        
        this._budget -= price;
        this.products.push(product);
        return `You have successfully bought ${product}!`;
    }

    recipes({ recipeName, productsList }){
        //let {recipeName, productsList} = recipeObj;

        if (productsList.some(p => this.products.includes(p) == false)) {
            throw new Error(`We do not have this product`);
        }

        this.dishes.push({ recipeName, productsList });

        return `${recipeName} has been successfully cooked!`
    }

    inviteGuests(name, dish){
        if (this.dishes.includes(dish == false)){
            throw new Error('We do not have this dish');
        }else if (!this.guests.hasOwnProperty(name)) {
            this.guests[name] = dish;  
            return `You have successfully invited ${name}!`; 
        }else{
            throw new Error('This guest has already been invited');
        }
        
    }

    showAttendance(){
        let result = [];
        // for (const guest in this.guests) {
        //     result.push(`${guest} will eat ${this.guests[guest]}, which consists of ${this.dishes.find(d => d.recipeName == this.guests[guest]).productsList.join(', ')}`);
            
        // }

        let entriesGuestList = Object.entries(this.guests);
        for (let guest of entriesGuestList) {
            let [name, dish] = guest;
            result.push(`${name} will eat ${dish}, which consists of ${this.dishes.find(d => d.recipeName == dish).productsList.join(", ")}`);
        }
        return result.join('\n');
    }

}

let dinner = new ChristmasDinner(-300);

console.log(dinner.shopping(['Salt', 1]));
console.log(dinner.shopping(['Beans', 3]));
console.log(dinner.shopping(['Cabbage', 4]));
console.log(dinner.shopping(['Rice', 2]));
console.log(dinner.shopping(['Savory', 1]));
console.log(dinner.shopping(['Peppers', 1]));
console.log(dinner.shopping(['Fruits', 40]));
console.log(dinner.shopping(['Honey', 10]));

console.log(dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
}));
console.log(dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
}));
console.log(dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
}));

console.log(dinner.inviteGuests('Ivan', 'Oshav'));
console.log(dinner.inviteGuests('Peter', 'Folded cabbage leaves filled with rice'));
console.log(dinner.inviteGuests('Georgi', 'Peppers filled with beans'));

console.log(dinner.showAttendance());;

