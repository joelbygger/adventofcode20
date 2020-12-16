from seating import Seating


def test_iterate_until_stable():
    seating = Seating("input_example")
    seating.iterate_until_stable()
    assert 37 == seating.count_occupied()


def test_iterate_until_stable():
    seating = Seating("input")
    seating.iterate_until_stable()
    assert 2281 == seating.count_occupied()
