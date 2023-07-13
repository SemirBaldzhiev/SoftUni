def is_valid_pass_len(password: str) -> bool:
    if 6 <= len(password) <= 10: return True
    else: return False

def is_contains_dig_let(password: str) -> bool:
    for c in password:
        if not c.isdigit() and not c.isalpha():
            return False
    return True

def is_contains_at_least_2_dig(password: str) -> bool:
    cnt_dig = 0
    for c in password:
        if c.isdigit(): cnt_dig+=1
    return cnt_dig >= 2

def validate_pass(password: str) -> str:
    valid = True
    if not is_valid_pass_len(password):
        valid = False
        print('Password must be between 6 and 10 characters')
    if not is_contains_dig_let(password):
        valid = False
        print('Password must consist only of letters and digits')
    if not is_contains_at_least_2_dig(password):
        valid = False
        print('Password must have at least 2 digits')
    if valid == True:
        print('Password is valid')
password = input()
validate_pass(password)