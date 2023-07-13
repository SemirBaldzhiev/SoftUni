len = int(input())
width = int(input())
height = int(input())
perc = float(input())
v = len * width * height
v_lt = v * 0.001
needed_lt = v_lt * (1-perc/100)
print(needed_lt)