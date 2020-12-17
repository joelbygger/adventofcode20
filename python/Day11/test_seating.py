from seating import Seating


def test_example1_occupied_when_finished():
    seating = Seating("input_example")
    seating.iterate_until_stable(ignore_floor=False, tolerant=False)
    assert 37 == seating.count_occupied()


def test_example1_single_step_check_layout():
    seating = Seating("input_example")

    seating1 = Seating("input_example_task1_iter1")
    seating.iterate_times(1, ignore_floor=False, tolerant=False)
    assert seating.get_seats() == seating1.get_seats()

    seating5 = Seating("input_example_task1_iter5")
    seating.iterate_times(4, ignore_floor=False, tolerant=False)
    assert seating.get_seats() == seating5.get_seats()


def test_real1_occupied_when_finished():
    seating = Seating("input")
    seating.iterate_until_stable(ignore_floor=False, tolerant=False)
    assert 2281 == seating.count_occupied()


def test_example2_occupied_when_finished():
    seating = Seating("input_example")
    seating.iterate_until_stable(ignore_floor=True, tolerant=True)
    assert 26 == seating.count_occupied()


def test_example2_single_step_check_layout():
    seating = Seating("input_example")

    seating1 = Seating("input_example_task2_iter1")
    seating.iterate_times(1, ignore_floor=True, tolerant=True)
    assert seating.get_seats() == seating1.get_seats()

    seating2 = Seating("input_example_task2_iter2")
    seating.iterate_times(1, ignore_floor=True, tolerant=True)
    assert seating.get_seats() == seating2.get_seats()

    seating6 = Seating("input_example_task2_iter6")
    seating.iterate_times(4, ignore_floor=True, tolerant=True)
    assert seating.get_seats() == seating6.get_seats()


def test_real2_occupied_when_finished():
    seating = Seating("input")
    seating.iterate_until_stable(ignore_floor=True, tolerant=True)
    assert 2085 == seating.count_occupied()
