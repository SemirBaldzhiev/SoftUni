class Weapon:
    def __init__(self, bullets):
        self.bullets = bullets

    def shoot(self) -> str:
        if self.bullets > 0:
            self.bullets -= 1
            return 'shooting...'
        else:
            return 'no bullets left'

    def __repr__(self) -> str:
        return f'Remaining bullets: {self.bullets}'
