import copy


def _direction():
    # If array index start at 0, 0 and we say that is top left, (x, y)
    yield -1, -1  # UL
    yield -1, 0  # L
    yield -1, 1  # UR
    yield 0, -1  # U
    yield 0, 1  # D
    yield 1, -1  # DL
    yield 1, 0  # R
    yield 1, 1  # DR


# def _in_matrix(pos, seats):
#    return 0 <= pos[0] < len(seats[0]) and 0 <= pos[1] < len(seats)


class Seating:
    def __init__(self, file):
        with open(file) as f:
            # A list of char arrays.
            self._seats = [list(x) for x in f.read().splitlines()]

    def _valid_position(self, pos):
        return 0 <= pos[0] < len(self._seats[0]) and 0 <= pos[1] < len(self._seats)

    def _calc_pos(self, pos, d, ignore_floor):
        n_pos = (pos[0] + d[0], pos[1] + d[1])
        if ignore_floor:
            while True:
                if not self._valid_position(n_pos) or not self._floor(self._seats[n_pos[1]][n_pos[0]]):
                    break
                n_pos = (n_pos[0] + d[0], n_pos[1] + d[1])

        return n_pos

    def _get_neighbor_seats(self, pos, ignore_floor):
        ns_pos = [self._calc_pos(pos, d, ignore_floor) for d in _direction()]
        ns_pos_valid = filter(self._valid_position, ns_pos)
        return [self._seats[x[1]][x[0]] for x in ns_pos_valid]

    @staticmethod
    def _free(seat):
        return seat == 'L'

    @staticmethod
    def _floor(seat):
        return seat == '.'

    @staticmethod
    def _occupied(seat):
        return seat == '#'

    def _seat_change(self, pos, neighbors, tolerant):
        curr = self._seats[pos[1]][pos[0]]
        occupied_cnt = len([n for n in neighbors if self._occupied(n)])

        if self._free(curr) and occupied_cnt == 0:
            curr = '#'
        elif self._occupied(curr):
            if not tolerant:
                if occupied_cnt >= 4:
                    curr = 'L'
            else:
                if occupied_cnt >= 5:
                    curr = 'L'

        return curr

    def _iterate(self, ignore_floor, tolerant):
        new_seats = copy.deepcopy(self._seats)

        for y, row in enumerate(self._seats):
            for x, seat in enumerate(row):
                neighbors = self._get_neighbor_seats((x, y), ignore_floor)
                seat = self._seat_change((x, y), neighbors, tolerant)
                if seat != self._seats[y][x]:
                    new_seats[y][x] = seat

        if self._seats == new_seats:
            return True
        else:
            self._seats = copy.deepcopy(new_seats)
            return False

    def iterate_until_stable(self, ignore_floor, tolerant):
        while True:
            if self._iterate(ignore_floor, tolerant):
                break
        return

    def iterate_times(self, iterations, ignore_floor, tolerant):
        while True:
            if iterations == 0 or self._iterate(ignore_floor, tolerant):
                break
            iterations -= 1

        return

    def count_occupied(self):
        cnt = 0
        for r in self._seats:
            for s in r:
                cnt += self._occupied(s)
        return cnt

    def get_seats(self):
        return copy.deepcopy(self._seats)
