import { TestBed } from '@angular/core/testing';

import { QuizzService } from './quizz.service';

describe('Quizz2Service', () => {
  let service: QuizzService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QuizzService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
