def age_assignment(*args, **kwargs):
    persons = dict()
    res = ''
    for k, v in kwargs.items():
        for name in args:
            if name[0] == k:
                persons[name] = v
    sorted_persons = dict(sorted(persons.items()))
    for k, v in sorted_persons.items():
        res += f'{k} is {v} years old.\n'
    return res