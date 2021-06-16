class List{
    constructor(){
        this.arr = [];
        this.size = 0;
    }

    add(element){
        this.arr.push(Number(element));
        this.arr.sort((a, b) => a - b);
        this.size++;
    }

    remove(index){
        if (index >= 0 && index < this.arr.length) {
            this.arr.splice(index, 1);
            this.size--;
        }
    }

    get(index){
        if (index >= 0 && index < this.arr.length) {
            return this.arr[index];
        } 
    }
}


let list = new List();
list.add(3);
list.add(5);
list.remove(0);
console.log(list.get(4));
console.log(list.size);



