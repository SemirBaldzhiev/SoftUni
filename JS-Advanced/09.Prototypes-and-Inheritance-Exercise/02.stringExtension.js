(function (){
    String.prototype.ensureStart = function(str) {
        if (this.startsWith(str)) {
            return this.toString();
        }

        return `${str}${this.toString()}`;
    };

    String.prototype.ensureEnd = function(str) {
        if (this.endsWith(str)) {
            return this.toString();
        }

        return `${this.toString()}${str}`;
    };

    String.prototype.isEmpty = function() {
        return this.toString() === '';
    };

    String.prototype.truncate = function(n) {
        if (this.length < n) {
            return this.toString();
        }

        if (this.toString().includes(' ')) {
            let words = this.split(' ');

            while(words.join(' ').length + 3 > n){
                words.pop();
            }

            let sentence = `${words.join(' ')}...`;
            return sentence;
        }

        if (n > 3) {
            let string = `${this.slice(0, n - 3)}...`;
            return string;
        }

        return '.'.repeat(n);
        
    };

    String.format = function (string, ...args) {
        for (let index = 0; index < args.length; ++index) {
            if (string.includes(`${index}`)) {
                string = string.replace(`{${index}}`, args[index]);
            }
        }

        return string;
    };
        
}())

let str = 'my string';
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
console.log(str);
str = String.format('jumps {0} {1}',
  'dog');
console.log(str);

