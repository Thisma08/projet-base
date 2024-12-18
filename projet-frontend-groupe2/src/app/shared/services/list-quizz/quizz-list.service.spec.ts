import { TestBed } from '@angular/core/testing';

import { QuizzListService } from './quizz-list.service';

describe('QuizzListService', () => {
  let service: QuizzListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QuizzListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
