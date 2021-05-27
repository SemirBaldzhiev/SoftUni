function solve(numStr, op1, op2, op3, op4, op5) {

    let num = Number(numStr);

    num = applyOperation(num, op1);
    num = applyOperation(num, op2);
    num = applyOperation(num, op3);
    num = applyOperation(num, op4);
    num = applyOperation(num, op5)

    function applyOperation(num, op){
        switch (op) {
            case 'chop':
                num /= 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num++;
                break;
            case 'bake':
                num *= 3;
                break;  
            case 'fillet':
                num = num - (num * 0.2);
                break;  
        }

        console.log(num);
        
        return num;
    }
}