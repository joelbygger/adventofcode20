from seating import Seating
import sys


def main(file, task):
    ignore_floor = False
    tolerant = False

    if task == '1':
        ignore_floor = False
        tolerant = False
    elif task == '2':
        ignore_floor = True
        tolerant = True
    else:
        print("This task is not supported...")
        return

    seating = Seating(file)
    seating.iterate_until_stable(ignore_floor, tolerant)
    print("Occupied seats task {}: {}".format(task, seating.count_occupied()))


if __name__ == "__main__":
    if len(sys.argv) != 3:
        print("Wrong number of argument, supply file and 1 or 2 for task 1 or 2.")
    else:
        main(sys.argv[1], sys.argv[2])
