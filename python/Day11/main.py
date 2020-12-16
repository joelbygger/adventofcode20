from seating import Seating
import sys


def main(file):
    seating = Seating(file)
    seating.iterate_until_stable()
    print("Occupied seats: ", seating.count_occupied())


if __name__ == "__main__":
    main(sys.argv[1])
