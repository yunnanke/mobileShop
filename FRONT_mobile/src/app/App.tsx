import { Navigate, Route, Routes } from "react-router-dom";
import { AppShell } from "../components/AppShell";
import { HomePage } from "../pages/HomePage";
import { ClientPortalPage } from "../pages/ClientPortalPage";
import { StaffPanelPage } from "../pages/StaffPanelPage";
import { AdminPanelPage } from "../pages/AdminPanelPage";
import { NotFoundPage } from "../pages/NotFoundPage";
import { useAuth } from "./AuthContext";
import type { DemoRole } from "../types/auth";

function ProtectedRoute({
  allowedRoles,
  children
}: {
  allowedRoles: DemoRole[];
  children: JSX.Element;
}) {
  const { session } = useAuth();

  if (!allowedRoles.includes(session.role)) {
    return <Navigate to="/" replace />;
  }

  return children;
}

export function App() {
  return (
    <AppShell>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route
          path="/client"
          element={
            <ProtectedRoute allowedRoles={["client", "admin"]}>
              <ClientPortalPage />
            </ProtectedRoute>
          }
        />
        <Route
          path="/staff"
          element={
            <ProtectedRoute allowedRoles={["consultant", "admin"]}>
              <StaffPanelPage />
            </ProtectedRoute>
          }
        />
        <Route
          path="/admin"
          element={
            <ProtectedRoute allowedRoles={["admin"]}>
              <AdminPanelPage />
            </ProtectedRoute>
          }
        />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </AppShell>
  );
}
