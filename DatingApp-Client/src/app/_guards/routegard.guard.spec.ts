import { TestBed, async, inject } from '@angular/core/testing';

import { RoutegardGuard } from './routegard.guard';

describe('RoutegardGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RoutegardGuard]
    });
  });

  it('should ...', inject([RoutegardGuard], (guard: RoutegardGuard) => {
    expect(guard).toBeTruthy();
  }));
});
