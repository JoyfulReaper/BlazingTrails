﻿export function initialize(hostElement, routeMapComponent) {
    hostElement.map = L.map(hostElement).setView([51.505, -0.09], 13);

    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
        maxZoom: 18,
        opacity: .75
    }).addTo(hostElement.map);

    hostElement.waypoints = [];
    hostElement.lines = [];

    hostElement.map.on('click', function (e) {
        let waypoint = L.marker(e.latlng);
        waypoint.addTo(hostElement.map);
        hostElement.waypoints.push(waypoint);
        let line = L.polyline(hostElement.waypoints.map(m => m.getLatLng()), { color: 'var(--brand)' }).addTo(hostElement.map);
        hostElement.lines.push(line);

        routeMapComponent.invokeMethodAsync('WaypointAdded', e.latlng.lat, e.latlng.lng);
    });
}

export function deleteLastWaypoint(hostElement) {
    if (hostElement.waypoints.length > 0) {
        let lastWaypoint = hostElement.waypoints[hostElement.waypoints.length - 1];
        hostElement.map.removeLayer(lastWaypoint);
        hostElement.waypoints.pop();

        if (hostElement.lines.length > 0) {
            let lastLine = hostElement.lines[hostElement.lines.length - 1];
            lastLine.remove(hostElement.map);
            hostElement.lines.pop();

            return `Deleted waypoint at latitude ${lastWaypoint.getLatLng().lat} and longitude ${lastWaypoint.getLatLng().lng}`;
        }
    }
}