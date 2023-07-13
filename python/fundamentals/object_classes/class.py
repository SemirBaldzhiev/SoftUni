class Class:
    __students_count = 22
    def __init__(self, name: str):
        self.name = name
        self.students = []
        self.grades = []
        
    def add_student(self, name: str, grade: float) -> None:
        if self.__students_count > 0:
            self.students.append(name)
            self.grades.append(grade)
            self.__students_count-=1
    def get_average_grade(self) -> float:
        return sum(self.grades) / len(self.grades)
    def __repr__(self) -> str:
        res = ', '.join(self.students)
        return f'The students in {self.name}: {res}. Average grade: {self.get_average_grade():.2f}'
