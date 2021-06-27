class Restaurant{
    constructor(budget){
        this.budgetMoney  = budget;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products){

        //let result = [];
        for (const product of products) {
            let [name, quantity, totalPrice] = product.split(' ');
            quantity = Number(quantity);
            totalPrice = Number(totalPrice);

            if (totalPrice <= this.budgetMoney ) {
                if (!this.stockProducts[name]) {
                    this.stockProducts[name] = quantity;
                }else{
                    this.stockProducts[name] += quantity;
                }

                this.budgetMoney  -= totalPrice;

                this.history.push(`Successfully loaded ${quantity} ${name}`);
            }else{
                this.history.push(`There was not enough money to load ${quantity} ${name}`);
            }

        }

    // console.log(this.stockProducts);

        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price){

        if (!this.menu[meal]) {
            this.menu[meal] = {neededProducts, price};

        }
        else{
            return `The ${meal} is already in the our menu, try something different.`;
        }

        let len = Object.keys(this.menu).length;

        //console.log(this.menu);
        if (len == 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        }else {
            return `Great idea! Now with the ${meal} we have ${len} meals in the menu, other ideas?`
        }

    }

    showTheMenu(){
        let entries  = Object.entries(this.menu);
        if (entries.length == 0) {
            return `Our menu is not ready yet, please come later...`;
        }

        let result = [];

        entries.forEach(e => {
            let value = Object.entries(this.menu[e[0]]);

            let kvp = value[1];

            result.push(`${e[0]} - $ ${kvp[1]}`);
            
        });

        return result.join('\n').trimEnd();
    }

    makeTheOrder(meal){
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        } else {

            let allProducts = false;

            let objProd = this.menu[meal];
            let products = objProd.neededProducts;

            for (const prod of products) {

                let prodKvp = prod.split(' ');

                if (this.stockProducts[prodKvp[0]] !== undefined && this.stockProducts[prodKvp[0]] >= Number(prodKvp[1])) {
                    allProducts = true;
                }else{
                    allProducts = false;
                    break;
                }
            }

            if (allProducts == false) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
            else{
                for (const [name, quantity] of products) {
                    this.stockProducts[name] -= quantity;
                }
                let price = this.menu[meal].price;
        
                this.budgetMoney  += price;
                
                //console.log(products);
        
                return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${price}.`;
            }
        }  
    }


}

//let kitchen = new Restaurant(1000);

//let kitchen = new Restaurant(1000);
//console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
//console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
//console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
//kitchen.makeTheOrder('frozenYogurt')
//console.log(kitchen.showTheMenu());

let kitchen = new Restaurant(1000);
kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10', 'Peach 9'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));

