import axios from 'axios';

const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL ?? 'http://localhost:5000/api',
  headers: {
    'Content-Type': 'application/json',
  },
});

export interface GoalPayload {
  title: string;
  description?: string;
  targetDate?: string;
}

export interface ProgressEntryPayload {
  goalId: number;
  date: string;
  notes?: string;
}

export async function fetchGoals() {
  const response = await api.get('/goals');
  return response.data;
}

export async function fetchGoalById(id: number) {
  const response = await api.get(`/goals/${id}`);
  return response.data;
}

export async function createGoal(payload: GoalPayload) {
  const response = await api.post('/goals', payload);
  return response.data;
}

export async function updateGoal(id: number, payload: Partial<GoalPayload> & { markCompleted?: boolean }) {
  const response = await api.put(`/goals/${id}`, payload);
  return response.data;
}

export async function completeGoal(id: number) {
  const response = await api.post(`/goals/${id}/complete`);
  return response.data;
}

export async function deleteGoal(id: number) {
  await api.delete(`/goals/${id}`);
}

export async function fetchProgressEntries(goalId: number) {
  const response = await api.get(`/goals/${goalId}/progress`);
  return response.data;
}

export async function createProgressEntry(payload: ProgressEntryPayload) {
  const response = await api.post(`/goals/${payload.goalId}/progress`, payload);
  return response.data;
}

export async function fetchDashboardSummary() {
  const response = await api.get('/dashboard');
  return response.data;
}
