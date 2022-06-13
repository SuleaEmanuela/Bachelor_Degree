import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateQrCodeComponent } from './update-qr-code.component';

describe('UpdateQrCodeComponent', () => {
  let component: UpdateQrCodeComponent;
  let fixture: ComponentFixture<UpdateQrCodeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateQrCodeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateQrCodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
