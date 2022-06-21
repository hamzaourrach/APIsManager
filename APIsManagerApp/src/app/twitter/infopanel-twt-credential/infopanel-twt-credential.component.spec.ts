import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfopanelTwtCredentialComponent } from './infopanel-twt-credential.component';

describe('InfopanelTwtCredentialComponent', () => {
  let component: InfopanelTwtCredentialComponent;
  let fixture: ComponentFixture<InfopanelTwtCredentialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InfopanelTwtCredentialComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfopanelTwtCredentialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
