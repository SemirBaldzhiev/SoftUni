def recursive_power(num, exp):
    if exp == 1:
        return num
    return num*recursive_power(num, exp-1)