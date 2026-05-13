export type DemoRole = "guest" | "client" | "consultant" | "admin";

export type DemoSession = {
  role: DemoRole;
  displayName: string;
  isAuthenticated: boolean;
};

export type LoginFormValues = {
  login: string;
  password: string;
  role: DemoRole;
};
