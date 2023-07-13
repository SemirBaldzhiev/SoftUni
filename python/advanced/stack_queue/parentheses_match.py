def main():
    expression = input()
    parentheses_idx = list()
    for i in range(len(expression)):
        if expression[i] == "(":
            parentheses_idx.append(i)
        elif expression[i] == ")":
            print_expr(parentheses_idx.pop(), i, expression)
            print()


def print_expr(start: int, end: int, expr: str) -> None:
    for i in range(end - start+1):
        print(expr[start+i], end = "")

main()