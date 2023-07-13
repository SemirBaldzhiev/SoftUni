def main():
    grades = dict()
    n = int(input())
    for _ in range(n):
        line = input().split(' ')
        if line[0] in grades:
            grades[line[0]].append(float(line[1]))
        else:
            grades[line[0]] = list()
            grades[line[0]].append(float(line[1]))
    for stud in grades:
        grades_str = ' '.join([f'{x:.2f}' for x in grades[stud]])
        print(f'{stud} -> {grades_str} (avg: {(sum(grades[stud])/len(grades[stud])):.2f})')
main()