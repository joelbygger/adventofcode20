import copy

def _direction():
    # If array index start at 0, 0 and we say that is top left, (x, y)
    yield -1, -1    # UL
    yield -1, 0     # L
    yield -1, 1     # UR
    yield 0, -1     # U
    yield 0, 1      # D
    yield 1, -1     # DL
    yield 1, 0      # R
    yield 1, 1      # DR

#def _in_matrix(pos, seats):
#    return 0 <= pos[0] < len(seats[0]) and 0 <= pos[1] < len(seats)



class Seating:
    def __init__(self, file):
        with open(file) as f:
            # A list of char arrays.
            self._seats = [list(x) for x in f.read().splitlines()]

    def _get_neighbor_seats(self, pos):
        neighbor_pos = [(pos[0] + d[0], pos[1] + d[1]) for d in _direction()]  # TODO tuple?
        neighbor_pos_valid = filter(
            lambda new_pos: (
                    0 <= new_pos[0] < len(self._seats[0]) and
                    0 <= new_pos[1] < len(self._seats)
            ),
            neighbor_pos)
        return [self._seats[x[1]][x[0]] for x in neighbor_pos_valid]


    def _free(self, seat):
        return seat == 'L'

    def _floor(self, seat):
        return seat == '.'

    def _occupied(self, seat):
        return seat == '#'

    def _seat_change(self, pos, neighbors):
        curr = self._seats[pos[1]][pos[0]]
        #free_cnt = len([self._free(n) or self._floor(n) for n in neighbors]) + 8 - len(neighbors)  # Outside cnt as free
        occupied_cnt = len([n for n in neighbors if self._occupied(n)])

        if self._free(curr) and occupied_cnt == 0:
            curr = '#'
        elif self._occupied(curr) and occupied_cnt >= 4:
            curr = 'L'

        return curr

    def iterate_until_stable(self):
        while True:
            new_seats = copy.deepcopy(self._seats)

            for y, row in enumerate(self._seats):
                for x, seat in enumerate(row):
                    neighbors = self._get_neighbor_seats((x, y))
                    seat = self._seat_change((x, y), neighbors)
                    if seat != self._seats[y][x]:
                        new_seats[y][x] = seat

            if self._seats == new_seats:
                break
            else:
                self._seats = copy.deepcopy(new_seats)

        return

    def count_occupied(self):
        cnt = 0
        for r in self._seats:
            for s in r:
                cnt += self._occupied(s)
        return cnt

