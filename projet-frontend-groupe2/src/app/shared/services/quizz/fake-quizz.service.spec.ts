import { TestBed } from '@angular/core/testing';

import { FakeQuizzService } from './fake-quizz.service';

describe('FakeQuizzService', () => {
  let service: FakeQuizzService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FakeQuizzService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
