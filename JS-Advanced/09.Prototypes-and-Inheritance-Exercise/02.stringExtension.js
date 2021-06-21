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
    
    String.prototype.truncate = function (n) {
        if(n <= 3){
            return ".".repeat(n);
        }
      if(this.toString().length <= n){
          return this.toString();
      } else {
          let lastIndex = this.toString().substr(0, n - 2).lastIndexOf(" ");
          if(lastIndex != -1){
              return this.toString().substr(0, lastIndex) + "...";
          } else {
              return this.toString().substr(0, n-3) + "...";
          }
      }
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

