import { TestBed } from '@angular/core/testing';

import { FakeThemeService } from './fake-theme.service';

describe('FakeThemeService', () => {
  let service: FakeThemeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FakeThemeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
