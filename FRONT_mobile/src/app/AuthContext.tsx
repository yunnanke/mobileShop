import {
  createContext,
  useContext,
  useEffect,
  useMemo,
  useState,
  type ReactNode
} from "react";
import type { DemoRole, DemoSession, LoginFormValues } from "../types/auth";

type AuthContextValue = {
  session: DemoSession;
  signIn: (values: LoginFormValues) => void;
  signOut: () => void;
  setRole: (role: DemoRole) => void;
};

const SESSION_KEY = "front-mobile-demo-session";

const defaultSession: DemoSession = {
  role: "guest",
  displayName: "Гость",
  isAuthenticated: false
};

const AuthContext = createContext<AuthContextValue | null>(null);

function roleLabel(role: DemoRole): string {
  switch (role) {
    case "client":
      return "Клиент";
    case "consultant":
      return "Сотрудник";
    case "admin":
      return "Администратор";
    default:
      return "Гость";
  }
}

export function AuthProvider({ children }: { children: ReactNode }) {
  const [session, setSession] = useState<DemoSession>(defaultSession);

  useEffect(() => {
    const raw = window.localStorage.getItem(SESSION_KEY);
    if (!raw) {
      return;
    }

    try {
      const parsed = JSON.parse(raw) as DemoSession;
      setSession(parsed);
    } catch {
      window.localStorage.removeItem(SESSION_KEY);
    }
  }, []);

  function persist(nextSession: DemoSession) {
    setSession(nextSession);
    window.localStorage.setItem(SESSION_KEY, JSON.stringify(nextSession));
  }

  function signIn(values: LoginFormValues) {
    persist({
      role: values.role,
      displayName: values.login || roleLabel(values.role),
      isAuthenticated: values.role !== "guest"
    });
  }

  function signOut() {
    window.localStorage.removeItem(SESSION_KEY);
    setSession(defaultSession);
  }

  function setRole(role: DemoRole) {
    persist({
      role,
      displayName: roleLabel(role),
      isAuthenticated: role !== "guest"
    });
  }

  const value = useMemo(
    () => ({
      session,
      signIn,
      signOut,
      setRole
    }),
    [session]
  );

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}

export function useAuth() {
  const context = useContext(AuthContext);

  if (!context) {
    throw new Error("useAuth must be used inside AuthProvider");
  }

  return context;
}
