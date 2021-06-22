function calculator() {
    let calculate = {}
    return {
        init: function() {
        calculate.num1 = document.getElementById('num1');
        calculate.num2 = document.getElementById('num2');
        calculate.result = document.getElementById('result');
    },
 
    add: function () {
        calculate.result.value = Number(calculate.num1.value) + Number(calculate.num2.value)
    },
    subtract: function () {
        calculate.result.value = Number(calculate.num1.value) - Number(calculate.num2.value)
    }
   }
}